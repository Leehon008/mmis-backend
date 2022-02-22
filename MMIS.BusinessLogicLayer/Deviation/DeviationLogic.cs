using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MMIS.DataAccessLayer.Shared;
using MMIS.DomainLayer.Authentication;
using MMIS.DomainLayer.Deviations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMIS.BusinessLogicLayer.Deviations
{
    public class DeviationLogic
    {
        public DeviationTemp _temp;

        private readonly MMISDbContext _context;

        public DeviationLogic(DeviationTemp temp, MMISDbContext context)
        {
            _temp = temp;
            _context = context;
        }

        public DeviationTemp Check()
        {
            var Parameters = _context.MandevDeviationMaster.Where(m => m.DCT.Equals(_temp.DCT));
            foreach (var param in _temp.Params)
            {
                if(Parameters.Where(m => m.Param.Equals(param.name)).Any())
                {
                    var compare = Parameters.Where(m => m.Param.Equals(param.name)).FirstOrDefault();
                    switch(compare.Type)
                    {
                        case "int":
                            param.IsValid = Convert.ToInt32(param.value).IsWithin(Convert.ToInt32(compare.LS),Convert.ToInt32(compare.HS));
                            param.required = compare.LS + " - " + compare.HS;
                            break;
                        case "double":
                            param.IsValid = Convert.ToDouble(param.value).IsWithin(Convert.ToDouble(compare.LS), Convert.ToDouble(compare.HS));
                            param.required = compare.LS + " - " + compare.HS;
                            break;
                        case "decimal":
                            param.IsValid = Convert.ToDecimal(param.value).IsWithin(Convert.ToDecimal(compare.LS), Convert.ToDecimal(compare.HS));
                            param.required = compare.LS + " - " + compare.HS;
                            break;
                        case "string":
                            param.IsValid = param.value.Contain(compare.SV);
                            param.required = compare.SV;
                            break;
                        default:
                            param.IsValid = true;
                            break;
                    }

                }
                else
                {
                    param.IsValid = true;
                }

                _temp.Deviating = !param.IsValid ? true : _temp.Deviating;
            }

            return _temp;
        }

        public async Task Process()
        {
            var temp = Check();
            if(temp.Deviating)
            {
                List<DParam> dParams = new List<DParam>();
                foreach(var param in temp.Params)
                {
                    if(!param.IsValid)
                    {
                        dParams.Add(new DParam
                        {
                            Name = param.name,
                            Standard = param.value,
                            Required = param.required
                        });
                    }
                }

                Deviation deviation = new Deviation
                {
                    Type = "Concession",
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    Personnel = temp.Personnel,
                    Plant = temp.Plant,
                    Date = temp.Date,
                    Function = temp.Function,
                    DCT = temp.DCT,
                    Parameters = dParams
                };

                _context.MandevDeviation.Add(deviation);
                await _context.SaveChangesAsync();
                Notify(deviation);
            }
        }

        public void Notify(Deviation deviation)
        {
            string notice = "";
            notice += "Kindly note that some parameters captured on the " + deviation.DCT + " have deviated from that standard\n";
            notice += "\nCaptured by : " + deviation.Personnel;
            notice += "\nPlant : " + deviation.Plant;
            notice += "\nDate : " + deviation.Date.ToString("dd-MM-yyyy");
            notice += "\nParameters :";
            foreach(var param in deviation.Parameters)
            {
                notice += "\n\t" + param.Name + " = " + param.Standard;
            }
            Notification notification = new Notification
            {
                Function = deviation.Function,
                DCT = deviation.DCT,
                Notice = notice
            };

            _context.MandevNotification.Add(notification);
            _context.SaveChangesAsync();
        }
    }

    public static class Comparator
    {
        public static bool IsWithin<T>(this T value, T minimum, T maximum) where T : IComparable<T>
        {
            if (value.CompareTo(minimum) < 0)
                return false;
            if (value.CompareTo(maximum) > 0)
                return false;
            return true;
        }

        public static bool Contain<T>(this T value, T available) where T : IComparable<T>
        {

            if (available.ToString().ToLower().Contains(value.ToString().ToLower()))
                return true;
            return false;
        }

    }
}
