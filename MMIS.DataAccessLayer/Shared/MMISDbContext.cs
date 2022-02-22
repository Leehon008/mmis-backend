using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MMIS.DomainLayer.Entities.Plants;
using MMIS.DomainLayer.Entities.Shifts;
using MMIS.DomainLayer.SHE.Entities;
using MMIS.DomainLayer.Quality.Entities;
using MMIS.DomainLayer.Quality.CentralLab.Entities;
using MMIS.DomainLayer.Brewing.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using MMIS.DomainLayer.UtilitiesEng.Entities;
using MMIS.DomainLayer.Maltings.Entities;
using MMIS.DomainLayer.ManDev.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MMIS.DomainLayer.Authentication;
using MMIS.DomainLayer.Entities.Users;
using MMIS.DomainLayer.Deviations.Entities;

namespace MMIS.DataAccessLayer.Shared
{
    public class MMISDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MMISDbContext(DbContextOptions<MMISDbContext> options) : base(options) { }

        public DbSet<DIArtisanInput> DIArtisanInput { get; set; }
       public DbSet<UserOld> UserOld { get; set; }
        public DbSet<PlantAccess> PlantAccess { get; set; }
        public DbSet<BrewingProcessTimeStds> BrewingProcessTimeStds { get; set; }
        public DbSet<PlantAccess> BrewingPlantAccess { get; set; }
        //public DbSet<UserType> UserType { get; set; }
        //public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<ProductionTimes> ProductionTimes { get; set; }
        public DbSet<Plant> PlantData { get; set; }
        //public DbSet<UserRole> UserRoleMaster { get; set; }
        public DbSet<Shifts> ShiftMaster { get; set; }
        //public DbSet<TeamLeaders> TeamLeaders { get; set; }
        //public DbSet<Operators> Operators { get; set; }
        public DbSet<Lines> Lines { get; set; }
        public DbSet<ShiftHeader> ShiftHeader { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<ShiftMeetingActions> ShiftMeetingActionItems { get; set; }
        public DbSet<ShiftAttendence> ShiftAttendence { get; set; }
        public DbSet<Inspections> Inspections { get; set; }
        public DbSet<EndShift> ShiftEnd { get; set; }
        //public DbSet<UserProfilevw> UserProfilevw { get; set; }
        public DbSet<FeedBackPanevw> FeedBackPanevw { get; set; }
        public DbSet<PIMsPOMs> PIMsPOMs { get; set; }
        public DbSet<LossWasteHeader> LossWasteHeader { get; set; }
        public DbSet<LossWasteFaults> LossWasteFaults { get; set; }
        public DbSet<LWInterval> LossWasteIntervals { get; set; }
        public DbSet<LossWasteJobCard> LossWasteJobCard { get; set; }
        public DbSet<DIPlannerInput> DIPlannerInput { get; set; }
        public DbSet<CMPlannerInput> CMPlannerInput { get; set; }
        public DbSet<CMArtisanInput> CMArtisanInput { get; set; }

        public DbSet<PIMsPOMsCompressor> PIMsPOMsCompressor { get; set; }

        public DbSet<PIMsPOMsBlowMoulder> PIMsPOMsBlowMoulder { get; set; }

        public DbSet<PIMsPOMsFiller> PIMsPOMsFiller { get; set; }

        public DbSet<PIMsPOMShrinkPacker> PIMsPOMShrinkPacker { get; set; }

        public DbSet<PIMsPOMsPasteurizer> PIMsPOMsPasteurizer { get; set; }

        public DbSet<PIMsPOMsRobobox> PIMsPOMsRobobox { get; set; }

        public DbSet<ShiftTeams> ShiftTeams { get; set; }

        //*****************************SHE Module Tables *********************************

        public DbSet<PreTaskRAHeader> PreTaskRAHeader { get; set; }
        public DbSet<PreTaskRAEquipment> PreTaskRAEquipment { get; set; }
        public DbSet<PreTaskRAHazards> PreTaskRAHazards { get; set; }
        public DbSet<PreTaskRAMembers> PreTaskRAMembers { get; set; }
        public DbSet<PreTaskRAPermisions> PreTaskRAPermisions { get; set; }
        public DbSet<SHERegistry> SHERegistry { get; set; }
        public DbSet<FRAEquipments> FRAEquipments { get; set; }
     
        public DbSet<FRAControls> FRAControls { get; set; }
     
        public DbSet<FRAHeader> FRAHeader { get; set; }
        public DbSet<FRARequirements> FRARequirements { get; set; }
        public DbSet<SRAControls> SRAControls { get; set; }
        public DbSet<SRAHeader> SRAHeader { get; set; }
        public  DbSet<SHETargetItems> SHETargetItems { get; set; }
        public DbSet<SRARequirements> SRARequirements { get; set; }
        public DbSet<HRAExposureRoute> HRAExposureRoute { get; set; }
        public DbSet<HRAAffectedPersons> HRAAffectedPersons { get; set; }
        public DbSet<HRAAssociatedRisk> HRAAssociatedRisk { get; set; }
        public DbSet<HRAClassification> HRAClassification { get; set; }
        public DbSet<HRAControls> HRAControls { get; set; }
        public DbSet<HRAEmergencyAction> HRAEmergencyAction { get; set; }

        public DbSet<ShiftStatus> ShiftStatus { get; set; }
        public DbSet<OccupationalControls> OccupationalControls { get; set; }
        public DbSet<OccupationalRequirements> OccupationalRequirements { get; set; }
 
        public DbSet<OccupationalHeader> OccupationalHeader { get; set; }

        public DbSet<EnvironmentalImpactControls> EnvironmentalImpactControls { get; set; }

        public DbSet<TrainingMatrix> TrainingMatrix { get; set; }
        public DbSet<Trainings> Trainings { get; set; }
        public DbSet<ChangeRequest> ChangeRequest { get; set; }
        public DbSet<SafeWorkMethod> SafeWorkMethod { get; set; }
        public DbSet<TasksInvolved> TasksInvolved { get; set; }
        public DbSet<SwmsTeam> SwmsTeam { get; set; }

        public DbSet<IncidentLogging> IncidentLogging { get; set; }
        public DbSet<Documents> IncidentDocuments { get; set; }
        public DbSet<Witnesses> IncidentWitnesses { get; set; }
        public DbSet<NatureOfIllness> IncidentNatureOfIllness { get; set; }
        public DbSet<EnvironmentalImpactRAHeader> EnvironmentalImpactRAHeader { get; set; }
        public DbSet<Suggestions> Suggestions { get; set; }
        public DbSet<MedicalData> MedicalData { get; set; }
        public DbSet<Medicals> Medicals { get; set; }
        public DbSet<PermitsAndLicenses> PermitsAndLicenses { get; set; }
        public DbSet<MonitoringPlan> MonitoringPlan { get; set; }
        public DbSet<SustainableDevelopment> SustainableDevelopment { get; set; }
        public DbSet<SDParameters> SDParameters { get; set; }
        public DbSet<HighRiskTaskObservationRecords> HighRiskTaskObservationRecords { get; set; }
        public DbSet<AuditRecords> AuditRecords { get; set; }
        public DbSet<InductionRequest> InductionRequest { get; set; }
        public DbSet<JobTitle> JobTitle { get; set; }
        public DbSet<InductionInventory> InductionInventory { get; set; }
        public DbSet<InductionInventoryContractors> InductionInventoryContractors { get; set; }
        public DbSet<LegalOtherRequirements> LegalOtherRequirements { get; set; }
        public DbSet<LegalOtherHeader> LegalOtherHeader { get; set; }
        public DbSet<HzSubstancesInventory> HzSubstancesInventory { get; set; }
        public DbSet<ChemicalCompatibility> ChemicalCompatibility { get; set; }
        public DbSet<ConfinedSpaces> ConfinedSpaces { get; set; }
        public DbSet<HeightWork> HeightWork { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<WasteManagement> WasteManagement { get; set; }
        public DbSet<WasteTracking> WasteTracking { get; set; }
        public DbSet<SupplierEvaluation> SupplierEvaluation { get; set; }
        public DbSet<CommunicationPlan> CommunicationPlan { get; set; }
        public DbSet<SystemDocumentation> SystemDocumentation { get; set; }
        public DbSet<SHETargetsHeader> SHETargetsHeader { get; set; }
        public DbSet<TrainingPlan> TrainingPlan { get; set; }
        public DbSet<HRAHandlingControls> HRAHandlingControls { get; set; }
        public DbSet<HRAImprovementSuggestion> HRAImprovementSuggestion { get; set; }
        public DbSet<HRAHeader> HRAHeader { get; set; }
        public DbSet<HRARequirements> HRARequirements { get; set; }
        public DbSet<HRASubstancesProduced> HRASubstancesProduced { get; set; }
        public DbSet<IncidentInvestigationToolCondition> IncidentInvestigationToolCondition { get; set; }
        public DbSet<IncidentInvestigationPPEList> IncidentInvestigationPPEList { get; set; }
        public DbSet<IncidentInvestigationDoneDifferent> IncidentInvestigationDoneDifferent { get; set; }
        public DbSet<IncidentInvestigationSteps> IncidentInvestigationSteps { get; set; }
        public DbSet<IncidentInvestigation> IncidentInvestigation { get; set; }
       public DbSet<IncidentVehicleInformation> IncidentVehicleInformation { get; set; }
        public DbSet<IncidentImmediateCauseConditions> IncidentImmediateCauseConditions { get; set; }
        public DbSet<IncidentRootCauseActions> IncidentRootCauseActions { get; set; }
        public DbSet<IncidentRootCauseConditions> IncidentRootCauseConditions { get; set; }
        public DbSet<IncidentWhys> IncidentWhys { get; set; }
        public DbSet<IncidentCauses> IncidentCauses { get; set; }
        public DbSet<IncidentDocumentDescription> IncidentDocumentDescription { get; set; }
        public DbSet<IncidentCorrectiveMeasures> IncidentCorrectiveMeasures { get; set; }
        public DbSet<EnvironmentalIncidentMedia> EnvironmentalIncidentMedia { get; set; }
        public DbSet<EnvironmentalIncident> EnvironmentalIncident { get; set; }
        public DbSet<EnvironmentalIncidentDeviationFromVpo> EnvironmentalIncidentDeviationFromVpo { get; set; }
        public DbSet<BrewingRawMatQuanties> BrewingRawMatQuanties { get; set; }
        public DbSet<BrewingTankStatus> BrewingTankStatus { get; set; }
        public DbSet<BrewerShiftHandOver> BrewerShiftHandOver { get; set; }
        
        public DbSet<BrewingPAShiftHandOver> BrewingPAShiftHandOver { get; set; }
        public DbSet<EnvironmentalIncidentInvestigation> EnvironmentalIncidentInvestigation { get; set; }
        public DbSet<EnvironmentalIncidentCorrectiveMeasures> EnvironmentalIncidentCorrectiveMeasures { get; set; }
        public DbSet<RATeams> HRATeams { get; set; }
        public DbSet<IncidentTypes> IncidentTypes { get; set; }
        public DbSet<SHEMails> SHEMails { get; set; }
        public DbSet<IssueBasedRAHeader> IssueBasedRAHeader { get; set; }
        public DbSet<IssueBasedRAItems> IssueBasedRAItems { get; set; }
        public DbSet<IssueBasedRAMembers> IssueBasedRAMembers { get; set; }
        public DbSet<IssueBasedRAAuthorisations> IssueBasedRAAuthorisations { get; set; }
        public DbSet<Appointments> SHEAppointments { get; set; }
        public DbSet<CostCalculator> CostCalculator { get; set; }
        public DbSet<ExpensesBreakDown> ExpensesBreakDown { get; set; }
        public DbSet<ManWorkedHours> SHEManWorkedHours { get; set; }


        //*****************************Quality Module Tables *********************************
        
         public DbSet<MealieMealRI> QualityRIMealieMeal { get; set; }
        public DbSet<AttenuzymeRI> QualityRIAttenuzymeRI { get; set; }
        public DbSet<ShakeShakeSleeve> QualityRIShakeShakeSleeve { get; set; }
        public DbSet<LayerBoardsRI> QualityRILayerBoardsRI { get; set; }
        
        public DbSet<CLMaizeRI> QualityCLRIMaize { get; set; }
        public DbSet<CLFOC> QualityCLFOC { get; set; }
        public DbSet<CLEA> QualityCLEA { get; set; }
        public DbSet<CLCIP> QualityCLCIP { get; set; }
        public DbSet<CLMDD> QualityCLMDD { get; set; }
        public DbSet<CLMicros> QualityCLMicros { get; set; }
        public DbSet<CLSMDD> QualityCLSMDD { get; set; }
        public DbSet<CLUtilities> QualityCLUtilities { get; set; }
        public DbSet<CLWater> QualityCLWater { get; set; }
        public DbSet<CLWDD> QualityCLWDD { get; set; }
        public DbSet<ErrorControlScud> QualityErrorControlScud { get; set; }
        public DbSet<ErrorControlSuper> QualityErrorControlSuper { get; set; }
        public DbSet<CLSorghumRI> QualityCLRISorghum { get; set; }
        public DbSet<CLYeastRI> QualityCLRIYeast { get; set; }
        public DbSet<Params> QualityParams { get; set; }
        public DbSet<Calibrations> QualityCalibrations { get; set; }
        public DbSet<CarbonDioxideRI> QualityRICarbonDioxide { get; set; }
        public DbSet<ClosureRI> QualityRIClosure { get; set; }
        public DbSet<ScudClosureRI> QualityRIScudClosure { get; set; }
        public DbSet<ScudBottleRI> QualityRIScudBottle { get; set; }
        public DbSet<MaizeRI> QualityRIMaize { get; set; }
        public DbSet<MaltRI> QualityRIMalt { get; set; }
        public DbSet<PreformRI> QualityRIPreform { get; set; }
        public DbSet<YeastRI> QualityRIYeast { get; set; }
        public DbSet<GlueRI> QualityRIGlue { get; set; }
        public DbSet<LabelRI> QualityRILabel { get; set; }
        public DbSet<LacticAcidRI> QualityRILacticAcid { get; set; }
        public DbSet<ShrinkfilmRI> QualityRIShrinkfilm { get; set; }
        public DbSet<StretchfilmRI> QualityRIStretchfilm { get; set; }
        public DbSet<Water> QualityWaterTreatment { get; set; }
        public DbSet<BulkWater> QualityBulkWater { get; set; }
        public DbSet<Wort> QualityWort { get; set; }
        public DbSet<TasteTest> QualityTasteTest { get; set; }
        public DbSet<PackagingInProgress> QualityPIP { get; set; }
        public DbSet<PackagingInProgressScud> QualityPIPScud { get; set; }
        public DbSet<PIPMaterials> QualityPIPMaterial { get; set; }
        public DbSet<PIPBrew> QualityPIPBrew { get; set; }
        public DbSet<MarketDispatched> QualityMarketDispatched { get; set; }
        public DbSet<CustomerComplaint> QualityCustomerComplaint { get; set; }
        public DbSet<Shelflife> QualityShelflife { get; set; }
        public DbSet<SLParameters> QualitySLParameters { get; set; }
        public DbSet<ShelflifeScud> QualityShelflifeScud { get; set; }
        public DbSet<SLParametersScud> QualitySLParametersScud { get; set; }
        public DbSet<DomainLayer.Quality.Entities.Fermentation> QualityFermentation { get; set; }
        public DbSet<DomainLayer.Quality.Entities.FermentationSuper> QualityFermentationSuper { get; set; }
        public DbSet<DomainLayer.Quality.Entities.FermentationScud> QualityFermentationScud { get; set; }
        public DbSet<FParameters> QualityFParameters { get; set; }
        public DbSet<CIPTracker> QualityCIPTracker { get; set; }
        public DbSet<WaterTreatment> QualityUtilitiesWT { get; set; }
        public DbSet<Boiler> QualityUtilitiesBoiler { get; set; }
        public DbSet<Vessel> QualityUtilitiesSoftner { get; set; }
        public DbSet<Vessel> QualityUtilitiesHotwell { get; set; }
        public DbSet<Condenser> QualityUtilitiesCondenser { get; set; }
        public DbSet<CoolingTower> QualityUtilitiesCoolingTower { get; set; }
        public DbSet<Refridgeration> QualityUtilitiesRefridgeration { get; set; }
        public DbSet<Effluent> QualityUtilitiesEffluent { get; set; }
        public DbSet<VUsage> QualityVUsage { get; set; }
        public DbSet<BlownBottles> QualityBlownBottles { get; set; }
        public DbSet<BottleSectionWeight> QualityBottleSectionWeight { get; set; }
        public DbSet<BSWItem> QualityBSWItem { get; set; }
        public DbSet<BottleVisualInspection> QualityBottleVisualInspection { get; set; }
        public DbSet<MarketQualityScore> QualityMarketQualityScore { get; set; }
        public DbSet<CompetitorProduct> QualityMQSCompetitorProduct { get; set; }
        public DbSet<MQSSuper> QualityMQSSuper { get; set; }
        public DbSet<MQSScud> QualityMQSScud { get; set; }
        public DbSet<PPQA> QualityPPQA { get; set; }
        public DbSet<PQIOther> QualityPQIOther { get; set; }
        public DbSet<PQIOtherScud> QualityPQIOtherScud { get; set; }
        public DbSet<BlownBottleDim> QualityBlownBottleDim { get; set; }


        //********************Brewing Module Tables**************************
        public DbSet<Inspection> BrewingInspections { get; set; }
        public DbSet<Brew> BrewingBrews { get; set; }
        public DbSet<BrewingCycle> BrewingCycles { get; set; }
        public DbSet<Process> BrewingProcesses { get; set; }
        public DbSet<Stoppage> BrewingStoppages { get; set; }
        public DbSet<StandardCheck> BrewingStdChecks { get; set; }
        public DbSet<CoolTo54> BrewingCoolTo54 { get; set; }
        public DbSet<Conversion> BrewingConversions { get; set; }
        public DbSet<ConversionPE> BrewingConversionPE { get; set; }
        public DbSet<Cooking> BrewingCooking { get; set; }
        public DbSet<CookingPE> BrewingCookingPE { get; set; }
        public DbSet<BrewingFermentation> BrewingFermentation { get; set; }
        public DbSet<BrewingVessels> BrewingVessels { get; set; }
        
        public DbSet<DomainLayer.Brewing.Entities.FermentationPE> BrewingFermentationPE { get; set; }
        public DbSet<Strain> BrewingStrain { get; set; }
        public DbSet<Vibro> BrewingVibro { get; set; }
        public DbSet<MaltAddition> BrewingMaltAddition { get; set; }
        public DbSet<SuperBBT> BrewingSuperBBT { get; set; }
        public DbSet<VibroPE> BrewingVibroPE { get; set; }
        public DbSet<WortCooling> BrewingWortCooling { get; set; }
        public DbSet<WortCoolingPE> BrewingWortCoolingPE { get; set; }
        public DbSet<YeastHandling> BrewingYeastHandling { get; set; }
        public DbSet<HeaderTank> BrewingHeaderTank { get; set; }
        public DbSet<HeaderTankPE> BrewingHeaderTankPE { get; set; }
        public DbSet<InProcessChecks> BrewingIPC { get; set; }
        public DbSet<StartMilling> BrewingStartMilling { get; set; }
        public DbSet<EndMilling> BrewingEndMilling { get; set; }

        //*****************************Utilities Module Tables *********************************
        public DbSet<HourlyUsageCO2> UtilitiesHourlyUsageCO2 { get; set; }
        public DbSet<HourlyUsageDiesel> UtilitiesHourlyUsageDiesel { get; set; }
        public DbSet<HourlyUsageElectricity> UtilitiesHourlyUsageElectricity { get; set; }
        public DbSet<HourlyUsageSteam> UtilitiesHourlyUsageSteam { get; set; }
        public DbSet<HourlyUsageWater> UtilitiesHourlyUsageWater { get; set; }
        public DbSet<Meter> UtilitiesMeter { get; set; }
        public DbSet<ShiftEnd> UtilitiesShiftEnd { get; set; }
        public DbSet<ShiftStart> UtilitiesShiftStart { get; set; }
        public DbSet<BCOL> UtilitiesBCOL { get; set; }
        public DbSet<IQMS> UtilitiesIQMS { get; set; }
        public DbSet<PREF> UtilitiesPREF { get; set; }
        public DbSet<CoalUsage> UtilitiesCoalUsage { get; set; }
        public DbSet<Unit> UtilitiesUnits { get; set; }


        //***************************** Maltings Module Tables *********************************
        public virtual DbSet<OverseerInput> MaltingsOverseerInput { get; set; }
        public virtual DbSet<MaltBatch> MaltingsMaltBatch { get; set; }
        public virtual DbSet<MStocks> MaltingsMStocks { get; set; }
        public virtual DbSet<MaltingCycle> MaltingsMaltingCycle { get; set; }
        public virtual DbSet<MProcess> MaltingsProcesses { get; set; }
        public virtual DbSet<MStoppage> MaltingsStoppages { get; set; }
        public virtual DbSet<WetEndMalt> MaltingsWetEndMalt { get; set; }
        public virtual DbSet<DryEndMalt> MaltingsDryEndMalt { get; set; }
        public virtual DbSet<Maintenance> MaltingsMaintenance { get; set; }
        public virtual DbSet<SorghumGrain> MaltingsSorghumGrain { get; set; }
        public virtual DbSet<Steeping> MaltingsSteeping { get; set; }
        public virtual DbSet<Germination> MaltingsGermination { get; set; }
        public virtual DbSet<Kilning> MaltingsKilning { get; set; }
        public virtual DbSet<MaltDryLoad> MaltingsDryLoad { get; set; }
        public virtual DbSet<MaltDispatch> MaltingsDispatch { get; set; }
        public virtual DbSet<MaltingTranfer> MaltingsTransfer { get; set; }
        public virtual DbSet<MaltMilling> MaltingsMilling { get; set; }
   
        public virtual DbSet<MaltProcesses> MaltingsMaltProcesses { get; set; }

        //***************************** ManDev Module Tables *********************************
        public virtual DbSet<AuditProtocol> MandevAuditProtocol { get; set; }
        public virtual DbSet<PlantRankingMaster> MandevPlantRankingMaster { get; set; }
        public virtual DbSet<PlantRanking> MandevPlantRanking { get; set; }
        public virtual DbSet<KPIBasketMaster> MandevKPIBasketMaster { get; set; }
        public virtual DbSet<KPIBasket> MandevKPIBasket { get; set; }
        public virtual DbSet<KPIMaster> MandevKPIMaster { get; set; }
        public virtual DbSet<KPI> MandevKPI { get; set; }
        public virtual DbSet<Clause> MandevClause { get; set; }
        public virtual DbSet<Section> MandevClauseSection { get; set; }
        public virtual DbSet<Evidence> MandevClauseSectionEvidence { get; set; }

        //***************************** Deviation Managemement Module Tables *********************************
        public virtual DbSet<DeviationMaster> MandevDeviationMaster { get; set; }
    
        public virtual DbSet<Deviation> MandevDeviation { get; set; }
        public virtual DbSet<DParam> MandevDeviationDParam { get; set; }
        public virtual DbSet<CorrectiveAction> MandevDeviationCorrectiveAction { get; set; }
        public virtual DbSet<TechnicalApproval> MandevDeviationTechnicalApproval { get; set; }
        public virtual DbSet<Approval> MandevDeviationApproval { get; set; }
        public virtual DbSet<Notification> MandevNotification { get; set; }
        public virtual DbSet<DeviationEmail> MandevDeviationEmail { get; set; }

        public virtual DbSet<ManWaySTs> ManWayStopThinks { get; set; }
        public virtual DbSet<ManWaySTHeader> ManWaySTHeader { get; set; }

        public virtual DbSet<MWSTsLineItems> MWSTsLineItems { get; set; }
        public virtual DbSet<MWSTsEmpowerment> MWSTsEmpowerment { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ///Packaging Schemas
            //modelBuilder.Entity<User>()
            // .HasKey(c => new { c.Id, c.UserName });
            //modelBuilder.Entity<UserType>()
            // .HasKey(c => new { c.Id, c.UserTypeId });
            //modelBuilder.Entity<UserGroup>()
            // .HasKey(c => new { c.Id, c.UserGroupID });
            //modelBuilder.Entity<Plant>()
            // .HasKey(c => new {c.Id, c.PlantId });
            //modelBuilder.Entity<UserProfilevw>(eb => {
            // eb.HasNoKey();
            // eb.ToView("UserProfilevw");});
            modelBuilder.Entity<FeedBackPanevw>(eb => {
             eb.HasNoKey();
             eb.ToView("FeedBackPanevw");});
            //modelBuilder.Entity<UserRole>()
            //.HasKey(c => new { c.Id, c.RoleId,c.RoleTypeId });
            modelBuilder.Entity<Shifts>()
            .HasKey(c => new { c.Id, c.ShiftId });
            modelBuilder.Entity<ShiftHeader>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("format(GETDATE(),'dddd, dd MMMM yyyy h:mm tt')");
            //modelBuilder.Entity<Operators>()
            //.HasKey(c => new { c.Id, c.OperatorId });
            //modelBuilder.Entity<TeamLeaders>()
            //.HasKey(c => new { c.Id, c.TeamLeaderId });
            modelBuilder.Entity<Lines>()
            .HasKey(c => new { c.Id, c.LineId });
            modelBuilder.Entity<ShiftHeader>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<ShiftHeader>()
            .Property(p => p.ShiftNo)
            .HasComputedColumnSql("+ 'SH' + cast([Id] as varchar)");
            modelBuilder.Entity<IncidentLogging>()
        .Property(p => p.IncidentNumber)
        .HasComputedColumnSql("+ 'IRX' + cast([Id] as varchar)");



            
            modelBuilder.Entity<ShiftMeetingActions>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<ShiftAttendence>()
            .HasKey(c => new { c.Id});
            modelBuilder.Entity<ShiftAttendence>()
            .Property(p => p.ShiftNo)
            .HasComputedColumnSql("+ 'SH' + cast([shiftHeaderId] as varchar)");
            modelBuilder.Entity<ShiftMeetingActions>()
            .Property(p => p.ShiftNo)
            .HasComputedColumnSql("+ 'SH' + cast([shiftHeaderId] as varchar)");
            modelBuilder.Entity<ShiftMeetingActions>()
            .Property(p => p.TaskNo)
            .HasComputedColumnSql("+ 'TAS' + cast([Id] as varchar)");
            modelBuilder.Entity<ShiftMeetingActions>()
            .Property(p => p.MeetingID)
            .HasComputedColumnSql("+ 'MT' + cast([shiftHeaderId] as varchar)");
            modelBuilder.Entity<Inspections>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PIMsPOMs>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<LossWasteHeader>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<LossWasteHeader>()
            .Property(p => p.LWId)
            .HasComputedColumnSql("+ 'LW' + cast([Id] as varchar)");
            modelBuilder.Entity<LossWasteHeader>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<EndShift>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<LossWasteFaults>()
            .Property(p => p.LWId)
            .HasComputedColumnSql("+ 'LW' + cast([LWHeaderId] as varchar)");
            modelBuilder.Entity<LossWasteFaults>()
            .Property(p => p.FaultNo)
            .HasComputedColumnSql("+ 'FN' + cast([Id] as varchar)");
            modelBuilder.Entity<LossWasteFaults>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<LossWasteFaults>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<LossWasteJobCard>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<LossWasteJobCard>()
            .Property(p => p.JobCardNo)
            .HasComputedColumnSql("+ 'JN' + cast([Id] as varchar)");
            modelBuilder.Entity<LossWasteJobCard>()
            .Property(p => p.FaultNo)
            .HasComputedColumnSql("+ 'FN' + cast([FaultId] as varchar)");
            modelBuilder.Entity<LossWasteJobCard>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<LossWasteFaults>()
            .HasOne(e => e.LWJobCard)
            .WithOne(c => c.LossWaste)
            .HasForeignKey<LossWasteJobCard>(c => c.FaultId);
            modelBuilder.Entity<DIPlannerInput>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<DIPlannerInput>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<DIPlannerInput>()
            .Property(p => p.IDNo)
            .HasComputedColumnSql("+ 'ID' + cast([Id] as varchar)");
            modelBuilder.Entity<DIArtisanInput>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<DIArtisanInput>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<DIArtisanInput>()
            .Property(p => p.IDNo)
            .HasComputedColumnSql("+ 'ID' + cast([Id] as varchar)");
            modelBuilder.Entity<CMPlannerInput>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<CMPlannerInput>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<CMPlannerInput>()
            .Property(p => p.IDNo)
            .HasComputedColumnSql("+ 'ID' + cast([Id] as varchar)");
            modelBuilder.Entity<CMArtisanInput>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<CMArtisanInput>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<CMArtisanInput>()
            .Property(p => p.IDNo)
            .HasComputedColumnSql("+ 'ID' + cast([Id] as varchar)");
            modelBuilder.Entity<PIMsPOMsCompressor>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PIMsPOMsCompressor>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PIMsPOMsBlowMoulder>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PIMsPOMsBlowMoulder>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PIMsPOMsFiller>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PIMsPOMsFiller>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PIMsPOMShrinkPacker>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PIMsPOMShrinkPacker>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PIMsPOMsRobobox>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PIMsPOMsRobobox>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<PIMsPOMsPasteurizer>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PIMsPOMsPasteurizer>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

            ///SHE SCHEMAS
            modelBuilder.Entity<PreTaskRAHeader>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<PreTaskRAHeader>()
            .Property(p => p.FormId)
            .HasComputedColumnSql("+ 'PRA' + cast([Id] as varchar)");
            modelBuilder.Entity<PreTaskRAHeader>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<PreTaskRAHazards>()
            .Property(p => p.FormId)
            .HasComputedColumnSql("+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)");
            modelBuilder.Entity<PreTaskRAHazards>()
            .Property(p => p.HazardNo)
            .HasComputedColumnSql("+ 'HN' + cast([Id] as varchar)");

            modelBuilder.Entity<PreTaskRAMembers>()
            .Property(p => p.FormId)
            .HasComputedColumnSql("+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)");
            modelBuilder.Entity<PreTaskRAMembers>()
            .Property(p => p.MemberNo)
            .HasComputedColumnSql("+ 'MN' + cast([Id] as varchar)");

            modelBuilder.Entity<PreTaskRAPermisions>()
            .Property(p => p.FormId)
            .HasComputedColumnSql("+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)");
            modelBuilder.Entity<PreTaskRAPermisions>()
            .Property(p => p.PermissionNo)
            .HasComputedColumnSql("+ 'PN' + cast([Id] as varchar)");

            modelBuilder.Entity<PreTaskRAEquipment>()
            .Property(p => p.FormId)
            .HasComputedColumnSql("+ 'PRA' + cast([PreTaskRAHeaderId] as varchar)");

            modelBuilder.Entity<IssueBasedRAHeader>()
            .HasKey(c => new { c.Id });
            modelBuilder.Entity<IssueBasedRAHeader>()
            .Property(p => p.DocumentNo)
            .HasComputedColumnSql("+ 'IBRA' + cast([Id] as varchar)");
            modelBuilder.Entity<IssueBasedRAHeader>()
            .Property(p => p.CreatedOn)
            .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<IssueBasedRAItems>()
            .Property(p => p.DocumentNo)
            .HasComputedColumnSql("+ 'IBRA' + cast([IssueBasedRAHeaderId] as varchar)");
            modelBuilder.Entity<IssueBasedRAMembers>()
            .Property(p => p.DocumentNo)
            .HasComputedColumnSql("+ 'IBRA' + cast([IssueBasedRAHeaderId] as varchar)");
            modelBuilder.Entity<IssueBasedRAAuthorisations>()
            .Property(p => p.DocumentNo)
            .HasComputedColumnSql("+ 'IBRA' + cast([IssueBasedRAHeaderId] as varchar)");


           // modelBuilder.Entity<Appointments>()
           //.Property(p => p.DateCreated)
           //.HasDefaultValueSql("GETDATE()");

           // modelBuilder.Entity<Appointments>()
           // .Property(p => p.DateModified)
           //.HasDefaultValueSql("GETDATE()");

           // modelBuilder.Entity<Appointments>()
           //.Property(p => p.Active)
           //.HasDefaultValue(true);

           //modelBuilder.Entity<Appointments>()
           //.HasKey(c => new { c.Id });



        }


    }
}
