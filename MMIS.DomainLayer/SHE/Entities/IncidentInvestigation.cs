using AutoMapper.Configuration;
using Microsoft.AspNetCore.Http;
using MMIS.CommonLayer.Automapper.Contracts;
using MMIS.DomainLayer.Entities.Shared;
using MMIS.DomainLayer.SHE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMIS.DomainLayer.SHE.Entities
{

    // Incident Investigation
    public class IncidentInvestigation: EntityBase
    {
        public string IncidentNumber { get; set; }
        public string Treatment { get; set; }
        public string TreatmentOther { get; set; }
        public string IncidentOccurrence { get; set; }
        public string IncidentPeriodPrior { get; set; }
        public string IncidentOccurrencePeriod { get; set; }
        public string Recordable { get; set; }
        public string KpiReportable { get; set; }
        public string TaskBeingDoneAction { get; set; }
        public string TaskBeingDoneObject { get; set; }
        public string TaskFrequency { get; set; }
        public string HighRisk { get; set; }
        public string WrittenProcedure { get; set; }
        public string ProcedureIdentification { get; set; }
        public string PersonTrained { get; set; }
        public string TaskDoneBefore { get; set; }
        public string SimilarSituations { get; set; }

        public string OtherPertinentInformation { get; set; }
        public string WorkPermits { get; set; }
 
        public string CorrectTools { get; set; }
        public string EquipmentInvolved { get; set; }
        public string EquipmentMaintenance { get; set; }
        public string StartUpPhase { get; set; }
 
        public string WhyWorkContinued { get; set; }
        public string Indication { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public string NOSANumber { get; set; }
        public string Company { get; set; }

        public virtual ICollection<IncidentInvestigationToolCondition> IncidentInvestigationToolCondition { get; set; }
        public virtual ICollection<IncidentInvestigationPPEList> IncidentInvestigationPPEList { get; set; }
        public virtual ICollection<IncidentInvestigationDoneDifferent> IncidentInvestigationDoneDifferent { get; set; }
        public virtual ICollection<IncidentInvestigationSteps> IncidentInvestigationSteps { get; set; }

    }
    public class IncidentInvestigationSteps: EntityBase
    {
        public virtual IncidentInvestigation IncidentInvestigation { get; set; }
        public DateTime StepDate { get; set; }
        public string StepDescription { get; set; }
    }

    public class IncidentInvestigationPPEList:EntityBase
    {
        public string Ppe { get; set; }
        public virtual IncidentInvestigation IncidentInvestigation { get; set; }
    }

    public class IncidentInvestigationToolCondition: EntityBase
    {
        public string Tool { get; set; }
        public string Condition { get; set; }
        public virtual IncidentInvestigation IncidentInvestigation { get; set; }
    }

    public class IncidentInvestigationDoneDifferent: EntityBase
    {
        public string Step { get; set; }
        public string Reason { get; set; }
        public virtual IncidentInvestigation IncidentInvestigation { get; set; }
    }

    public class IncidentVehicleInformation :EntityBase
    {
        public string IncidentNumber { get; set; }
        public string DriverName { get; set; }

      

        public string LicenseNumber { get; set; }
        public string LicenseType { get; set; }
        public string LicenseTypeOther { get; set; }
        public string StateOfIssue { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public DateTime DateOfLastDefensive { get; set; }
        public string CompanyVehicle { get; set; }
        public string TypeOfCar { get; set; }
        public string TypeOfCarOther { get; set; }
        public string YearOfVehicle { get; set; }
        public int SeatsAvailable { get; set; }
        public string Capacity { get; set; }
        public DateTime LastInspection { get; set; }
        public int NumberOfOccupants { get; set; }
        public string SeatBeltsUsed { get; set; }
        public string OccupantOne { get; set; }
        public string OccupantTwo { get; set; }
        public string Authorized { get; set; }
        public string Maintenance { get; set; }
        public string WithinHoursOfService { get; set; }
        public string SafeDrivingPractices { get; set; }
        public string Distracted { get; set; }
        public string RollOver { get; set; }
        public string SpeedLimit { get; set; }
        public string TravellingSpeed { get; set; }
        public string LoadWeight { get; set; }
        public string WeatherConditions { get; set; }
        public string RoadConditions { get; set; }
        public string AccidentDescription { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }

    }

    public class  IncidentDocumentDescription :EntityBase
    {

        public string IncidentNumber { get; set; }
        public string CreatedBy { get; set; }
        public string FilePath { get; set; }

        public string Description { get; set; }

    }

    public class IncidentDocumentDescriptionDto : IHaveCustomMappings
    {

        public string IncidentNumber { get; set; }
        public string CreatedBy { get; set; }
        public string FilePath { get; set; }

        public string Description { get; set; }
        [NotMapped]
        public IFormFile files { get; set; }

        public void CreateMaps(MapperConfigurationExpression config)
        {
            config.CreateMap<IncidentDocumentDescription, IncidentDocumentDescriptionDto>().ReverseMap();
        }

    }


    public class IncidentCorrectiveMeasures:EntityBase
    {
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public string IncidentNumber { get; set; }
        public string IncidentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Label { get; set; }
        public DateTime DueDate { get; set; }
    
    }
    




    ///ENVIRONMEMTAL INCIDENTS
    ///
    public class EnvironmentalIncident:EntityBase
    {
        public string IncidentNumber { get; set; }

        public string CreatedBy { get; set; }
        public string Centre { get; set; }
        public string Department { get; set; }
        public string Country { get; set; }
        public string DateTimeOfIncident { get; set; }
        public string DescriptionOfIncident { get; set; }
        public string EquipmentInvolved { get; set; }
        public string ImpactOnEnvironment { get; set; }
        public string ImpactOnEnvironmentOther { get; set; }
        public string IncidentClassification { get; set; }
        public string FacilityStoppage { get; set; }
        public string DurationOfShutdown { get; set; }
        public string MediaCoverage { get; set; }
        public string CrisisTeam { get; set; }
        public string CrisisTeamDetail { get; set; }
        public string AuthoritiesInvolved { get; set; }
        public string AuthoritiesInvolvedDetail { get; set; }
        public string ImmediateActions { get; set; }
        public string InvestigationStarted { get; set; }
        public string HumanBehavior { get; set; }
        public string BehaviorExplanation { get; set; }
        public string PsmRecordableIncident { get; set; }
        public string Status { get; set; }
        public string Company { get; set; }
        public string Damage { get; set; }
        public string NaturalDisaster { get; set; }
       public virtual ICollection<EnvironmentalIncidentMedia> EnvironmentalIncidentMedia { get; set; }
    }

    public class EnvironmentalIncidentMedia:EntityBase
    {
        public string IncidentNumber { get; set; }
        public string FilePath { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }



    }
    public class EnvironmentalIncidentCorrectiveMeasures : EntityBase
    {
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public string IncidentNumber { get; set; }
        public string IncidentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }
        public string Label { get; set; }
        public DateTime DueDate { get; set; }

    }

    public class EnvironmentalIncidentInvestigation :EntityBase
    {
        public string IncidentNumber { get; set; }
        public string CreatedBy { get; set; }
        public string Status { get; set; }
        public string FinalIncidentClassification { get; set; }
        public string ViolationOfLegalRequirements { get; set; }
        public string PermitExcursion { get; set; }
        public string NotificationToAuthorities { get; set; }
        public string NotificationToAuthoritiesDetail { get; set; }
        public string NotificationDateTime { get; set; }
        public string ExternalNotification { get; set; }
        public string AgencyNotification { get; set; }
        public string CaInvolvement { get; set; }
        public string ImpactOnDailyOperation { get; set; }
        public string ReleaseBeyondFacility { get; set; }
        public string ReleaseBeyondFacilityDetails { get; set; }
        public string KpiImpact { get; set; }
        public string EquipmentFailure { get; set; }
        public string MaintenanceIssue { get; set; }
        public string HazMatTeam { get; set; }
        public string HazMatLocation { get; set; }
        public string HazMatDescription { get; set; }
        public string HazmatActions { get; set; }
        public string HazMatReasons { get; set; }
        public virtual ICollection<EnvironmentalIncidentDeviationFromVpo> EnvironmentalIncidentDeviationFromVpo { get; set; }
        public string IncidentviolationOfVpo { get; set; }
        public string VpoIdentified { get; set; }
        public string ViolationOfVpoOther { get; set; }
        public string RootCauseFailureAnalysis { get; set; }
        public string NonComplianceClosed { get; set; }
    }

    public class EnvironmentalIncidentDeviationFromVpo : EntityBase
    {
        public string IncidentNumber { get; set; }
        public string Deviation { get; set; }
        public virtual EnvironmentalIncidentInvestigation EnvironmentalIncidentInvestigation { get; set; }
    }



}









