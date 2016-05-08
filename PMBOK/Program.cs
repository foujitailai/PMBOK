using System;

namespace PMBOK
{


	//1 Integration
	//2 Scope
	//3 Time
	//4 Cost
	//5 Quality
	//6 Human Resource
	//7 Communications
	//8 Risk
	//9 Procurement
	//10 Stakeholder
	class ProjectManagement
	{
		ProjectCharter	m_ProjectCharter;
		ProjectStatementOfWork	m_ProjectStatementOfWork;
		BusinessCase	m_BusinessCase;
		Agreements	m_Agreements;
		EnterpriseEnvironmentalFactors	m_EnterpriseEnvironmentalFactors;
		OrganizationalProcessAssets	m_OrganizationalProcessAssets;
		StakeholderRegister	m_StakeholderRegister;
		ProcurementDocuments	m_ProcurementDocuments;
		ProjectManagementPlan	m_ProjectManagementPlan;
		OutputsFromOtherProcesses	m_OutputsFromOtherProcesses = new OutputsFromOtherProcesses();
		ScopeManagementPlan	m_ScopeManagementPlan;
		RequirementsManagementPlan	m_RequirementsManagementPlan;
		RequirementsDocumentation	m_RequirementsDocumentation;
		RequirementsTraceabilityMatrix	m_RequirementsTraceabilityMatrix;
		StakeholderManagementPlan	m_StakeholderManagementPlan;
		ProjectScopeStatement	m_ProjectScopeStatement;
		ProjectDocumentsUpdates	m_ProjectDocumentsUpdates;
		ScopeBaseline	m_ScopeBaseline;
		ScheduleManagementPlan	m_ScheduleManagementPlan;
		ActivityList	m_ActivityList;
		ActivityAttributes	m_ActivityAttributes;
		MilestoneList	m_MilestoneList;
		ProjectScheduleNetworkDiagrams	m_ProjectScheduleNetworkDiagrams;
		ActivityResourceRequirements	m_ActivityResourceRequirements;
		ResourceBreakdownStructure	m_ResourceBreakdownStructure;
		ResourceCalendars	m_ResourceCalendars;
		RiskRegister	m_RiskRegister;
		ActivityCostEstimates	m_ActivityCostEstimates;
		ActivityDurationEstimates	m_ActivityDurationEstimates;
		ScheduleBaseline	m_ScheduleBaseline;
		ProjectSchedule	m_ProjectSchedule;
		ScheduleData	m_ScheduleData;
		ProjectCalendars	m_ProjectCalendars;
		ProjectManagementPlanUpdates	m_ProjectManagementPlanUpdates;
		ProjectStaffAssignments	m_ProjectStaffAssignments;
		CostManagementPlan	m_CostManagementPlan;
		BasisOfEstimates	m_BasisOfEstimates;
		HumanResourceManagementPlan	m_HumanResourceManagementPlan;
		CostBaseline	m_CostBaseline;
		ProjectFundingRequirements	m_ProjectFundingRequirements;
		QualityManagementPlan	m_QualityManagementPlan;
		ProcessImprovementPlan	m_ProcessImprovementPlan;
		QualityMetrics	m_QualityMetrics;
		QualityChecklists	m_QualityChecklists;
		CommunicationsManagementPlan	m_CommunicationsManagementPlan;
		RiskManagementPlan	m_RiskManagementPlan;
		ProjectDocuments	m_ProjectDocuments;
		ProcurementManagementPlan	m_ProcurementManagementPlan;
		ProcurementStatementOfWork	m_ProcurementStatementOfWork;
		MakeOrBuyDecisions	m_MakeOrBuyDecisions;
		ChangeRequests	m_ChangeRequests;
		FinalProductServiceOrResultTransition m_FinalProductServiceOrResultTransition;
		OrganizationalProcessAssetsUpdates m_OrganizationalProcessAssetsUpdates;
		AcceptedDeliverables m_AcceptedDeliverables;
		ClosedProcurements m_ClosedProcurements;
		Deliverables	m_Deliverables;
		WorkPerformanceData	m_WorkPerformanceData;
		ApprovedChangeRequests	m_ApprovedChangeRequests;
		QualityControlMeasurements	m_QualityControlMeasurements;
		TeamPerformanceAssessments	m_TeamPerformanceAssessments;
		EnterpriseEnvironmentalFactorsUpdates	m_EnterpriseEnvironmentalFactorsUpdates;
		IssueLog	m_IssueLog;
		WorkPerformanceReports	m_WorkPerformanceReports;
		ProjectCommunications	m_ProjectCommunications;
		SelectedSellers	m_SelectedSellers;
		ResourceCalendar	m_ResourceCalendar;
		SellerProposals	m_SellerProposals;
		ChangeLog	m_ChangeLog;
		ScheduleForecasts	m_ScheduleForecasts;
		CostForecasts	m_CostForecasts;
		ValidatedChanges	m_ValidatedChanges;
		WorkPerformanceInformation	m_WorkPerformanceInformation;
		VerifiedDeliverables	m_VerifiedDeliverables;
		SourceSelectionCriteria	m_SourceSelectionCriteria;

		public virtual void Initiating()
		{
			Console.WriteLine("> > > Initiating...");

			DevelopProjectCharter(m_ProjectStatementOfWork, m_BusinessCase, m_Agreements, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			IdentifyStakeholders(m_ProjectCharter, m_ProcurementDocuments, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
		}
			
		ProjectCharter DevelopProjectCharter(
			ProjectStatementOfWork psow,
			BusinessCase bc,
			Agreements a,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new ProjectCharter ();
		}

		StakeholderRegister IdentifyStakeholders(
			ProjectCharter pc,
			ProcurementDocuments pd,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new StakeholderRegister ();
		}


		public virtual void Planning()
		{
			Console.WriteLine("> > > Planning...");

			DevelopProjectManagementPlan(m_ProjectCharter, m_OutputsFromOtherProcesses, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanScopeManagement(m_ProjectManagementPlan, m_ProjectCharter, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			CollectRequirements(m_ScopeManagementPlan, m_RequirementsManagementPlan, m_StakeholderManagementPlan, m_ProjectCharter, m_StakeholderRegister);
			DefineScope(m_ScopeManagementPlan, m_ProjectCharter, m_RequirementsDocumentation, m_OrganizationalProcessAssets);
			CreateWBS(m_ScopeManagementPlan, m_ProjectScopeStatement, m_RequirementsDocumentation, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanScheduleManagement(m_ProjectManagementPlan, m_ProjectCharter, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			DefineActivities(m_ScheduleManagementPlan, m_ScopeBaseline, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			SequenceActivities(m_ScheduleManagementPlan, m_ActivityList, m_ActivityAttributes, m_MilestoneList, m_ProjectScopeStatement, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			EstimateActivityResources(m_ScheduleManagementPlan, m_ActivityList, m_ActivityAttributes, m_ResourceCalendars, m_RiskRegister, m_ActivityCostEstimates, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			EstimateActivityDurations(m_ScheduleManagementPlan, m_ActivityList, m_ActivityAttributes, m_ActivityResourceRequirements, m_ResourceCalendars, m_ProjectScopeStatement, m_RiskRegister, m_ResourceBreakdownStructure, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			DevelopSchedule(m_ScheduleManagementPlan, m_ActivityList, m_ActivityAttributes, m_ProjectScheduleNetworkDiagrams, m_ActivityResourceRequirements, m_ResourceCalendars, m_ActivityDurationEstimates, m_ProjectScopeStatement, m_RiskRegister, m_ProjectStaffAssignments, m_ResourceBreakdownStructure, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanCostManagement(m_ProjectManagementPlan, m_ProjectCharter, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			EstimateCosts(m_CostManagementPlan, m_HumanResourceManagementPlan, m_ScopeBaseline, m_ProjectSchedule, m_RiskRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			DetermineBudget(m_CostManagementPlan, m_ScopeBaseline, m_ActivityCostEstimates, m_BasisOfEstimates, m_ProjectSchedule, m_ResourceCalendars, m_RiskRegister, m_Agreements, m_OrganizationalProcessAssets);
			PlanQualityManagement(m_ProjectManagementPlan, m_StakeholderRegister, m_RiskRegister, m_RequirementsDocumentation, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanHumanResourceManagement(m_ProjectManagementPlan, m_ActivityResourceRequirements, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanCommunicationsManagement(m_ProjectManagementPlan, m_StakeholderRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanRiskManagement(m_ProjectManagementPlan, m_ProjectCharter, m_StakeholderRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			IdentifyRisks(m_RiskManagementPlan, m_CostManagementPlan, m_ScheduleManagementPlan, m_QualityManagementPlan, m_HumanResourceManagementPlan, m_ScopeBaseline, m_ActivityCostEstimates, m_ActivityDurationEstimates, m_StakeholderRegister, m_ProjectDocuments, m_ProcurementDocuments, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PerformQualitativeRiskAnalysis(m_RiskManagementPlan, m_ScopeBaseline, m_RiskRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PerformQuantitativeRiskAnalysis(m_RiskManagementPlan, m_CostManagementPlan, m_ScheduleManagementPlan, m_RiskRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanRiskResponses(m_RiskManagementPlan, m_RiskRegister);
			PlanProcurementManagement(m_ProjectManagementPlan, m_RequirementsDocumentation, m_RiskRegister, m_ActivityResourceRequirements, m_ProjectSchedule, m_ActivityCostEstimates, m_StakeholderRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
			PlanStakeholderManagement(m_ProjectManagementPlan, m_StakeholderRegister, m_EnterpriseEnvironmentalFactors, m_OrganizationalProcessAssets);
		}

		// A1 develop Project Management Plan
		//  Project charter
		//  Outputs from other processes
		//  Enterprise environmental factors
		//  Organizational process assets
		//  Project management plan
		ProjectManagementPlan DevelopProjectManagementPlan(
			ProjectCharter pc,
			OutputsFromOtherProcesses ofop,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			if (pc == null) Console.WriteLine ("ProjectCharter is invalid");
			if (ofop == null) Console.WriteLine ("OutputsFromOtherProcesses is invalid");
			if (eef == null) Console.WriteLine ("EnterpriseEnvironmentalFactors is invalid");
			if (opa == null) Console.WriteLine ("OrganizationalProcessAssets is invalid");
			return new ProjectManagementPlan ();
		}

		class PlanScopeManagementResult
		{
			ScopeManagementPlan smp;
			RequirementsManagementPlan rmp;
		}
		PlanScopeManagementResult PlanScopeManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets op)
		{
			return new PlanScopeManagementResult ();
		}

		class CollectRequirementsResult
		{
			RequirementsDocumentation rd;
			RequirementsTraceabilityMatrix rtm;
		}
		CollectRequirementsResult CollectRequirements(
			ScopeManagementPlan smp,
			RequirementsManagementPlan rmp,
			StakeholderManagementPlan shmp,
			ProjectCharter pc,
			StakeholderRegister sr)
		{
			return new CollectRequirementsResult();
		}

		class DefineScopeResult
		{
			ProjectScopeStatement pss;
			ProjectDocumentsUpdates pdu;
		}
		DefineScopeResult DefineScope(
			ScopeManagementPlan smp,
			ProjectCharter pc,
			RequirementsDocumentation rd,
			OrganizationalProcessAssets opa)
		{
			return new DefineScopeResult ();
		}

		class CreateWBSResult
		{
			ScopeBaseline sb;
			ProjectDocumentsUpdates pdu;
		}
		CreateWBSResult CreateWBS(
			ScopeManagementPlan smp,
			ProjectScopeStatement pss,
			RequirementsDocumentation rd,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new CreateWBSResult ();
		}

		ScheduleManagementPlan PlanScheduleManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new ScheduleManagementPlan ();
		}

		class DefineActivitiesResult
		{
			ActivityList al;
			ActivityAttributes aa;
			MilestoneList ml;
		}
		DefineActivitiesResult DefineActivities(
			ScheduleManagementPlan smp,
			ScopeBaseline sb,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new DefineActivitiesResult ();
		}

		class SequenceActivitiesResult
		{
			ProjectScheduleNetworkDiagrams psnd;
			ProjectDocumentsUpdates pdu;
		}
		SequenceActivitiesResult SequenceActivities(
			ScheduleManagementPlan smp,
			ActivityList al,
			ActivityAttributes aa,
			MilestoneList ml,
			ProjectScopeStatement pss,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new SequenceActivitiesResult ();
		}

		class EstimateActivityResourcesResult
		{
			ActivityResourceRequirements arr;
			ResourceBreakdownStructure rbs;
			ProjectDocumentsUpdates pdu;
		}
		EstimateActivityResourcesResult EstimateActivityResources(
			ScheduleManagementPlan smp,
			ActivityList al,
			ActivityAttributes aa,
			ResourceCalendars rc,
			RiskRegister rr,
			ActivityCostEstimates ace,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new EstimateActivityResourcesResult ();
		}

		class EstimateActivityDurationsResult
		{
			ActivityDurationEstimates ade;
			ProjectDocumentsUpdates pdu;
		}
		EstimateActivityDurationsResult EstimateActivityDurations(
			ScheduleManagementPlan smp,
			ActivityList al,
			ActivityAttributes aa,
			ActivityResourceRequirements arr,
			ResourceCalendars rc,
			ProjectScopeStatement pss,
			RiskRegister rr,
			ResourceBreakdownStructure rbs,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new EstimateActivityDurationsResult ();
		}

		class DevelopScheduleResult
		{
			ScheduleBaseline sb;
			ProjectSchedule ps;
			ScheduleData sd;
			ProjectCalendars pc;
			ProjectManagementPlanUpdates pmp;
			ProjectDocumentsUpdates pdu;
		}
		DevelopScheduleResult DevelopSchedule(
			ScheduleManagementPlan smp,
			ActivityList al,
			ActivityAttributes aa,
			ProjectScheduleNetworkDiagrams psnd,
			ActivityResourceRequirements arr,
			ResourceCalendars rc,
			ActivityDurationEstimates ade,
			ProjectScopeStatement pss,
			RiskRegister rr,
			ProjectStaffAssignments psa,
			ResourceBreakdownStructure rbs,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new DevelopScheduleResult ();
		}

		CostManagementPlan PlanCostManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new CostManagementPlan ();
		}

		class EstimateCostsResult
		{
			ActivityCostEstimates ace;
			BasisOfEstimates boe;
			ProjectDocumentsUpdates pdu;
		}
		EstimateCostsResult EstimateCosts(
			CostManagementPlan cmp,
			HumanResourceManagementPlan hrmp,
			ScopeBaseline sb,
			ProjectSchedule ps,
			RiskRegister rr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new EstimateCostsResult ();
		}

		class DetermineBudgetResult
		{
			CostBaseline cb;
			ProjectFundingRequirements pfr;
			ProjectDocumentsUpdates pdu;
		}
		DetermineBudgetResult DetermineBudget(
			CostManagementPlan cmp,
			ScopeBaseline sb,
			ActivityCostEstimates ace,
			BasisOfEstimates boe,
			ProjectSchedule ps,
			ResourceCalendars rc,
			RiskRegister rr,
			Agreements a,
			OrganizationalProcessAssets opa)
		{
			return new DetermineBudgetResult ();
		}

		class PlanQualityManagementResult
		{
			QualityManagementPlan qmp;
			ProcessImprovementPlan pip;
			QualityMetrics qm;
			QualityChecklists qc;
			ProjectDocumentsUpdates pdu;
		}
		PlanQualityManagementResult PlanQualityManagement(
			ProjectManagementPlan pmp,
			StakeholderRegister sr,
			RiskRegister rr,
			RequirementsDocumentation rd,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new PlanQualityManagementResult ();
		}

		HumanResourceManagementPlan PlanHumanResourceManagement(
			ProjectManagementPlan pmp,
			ActivityResourceRequirements arr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new HumanResourceManagementPlan ();
		}

		class PlanCommunicationsManagementResult
		{
			CommunicationsManagementPlan cmp;
			ProjectDocumentsUpdates pdu;
		}
		PlanCommunicationsManagementResult PlanCommunicationsManagement(
			ProjectManagementPlan pmp,
			StakeholderRegister sr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new PlanCommunicationsManagementResult ();
		}

		RiskManagementPlan PlanRiskManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			StakeholderRegister sr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new RiskManagementPlan ();
		}

		RiskRegister IdentifyRisks(
			RiskManagementPlan rmp,
			CostManagementPlan cmp,
			ScheduleManagementPlan smp,
			QualityManagementPlan qmp,
			HumanResourceManagementPlan hrmp,
			ScopeBaseline sb,
			ActivityCostEstimates ace,
			ActivityDurationEstimates ade,
			StakeholderRegister sr,
			ProjectDocuments pjd,
			ProcurementDocuments pd,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new RiskRegister ();
		}

		ProjectDocumentsUpdates PerformQualitativeRiskAnalysis(
			RiskManagementPlan rmp,
			ScopeBaseline sb,
			RiskRegister rr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new ProjectDocumentsUpdates ();
		}

		ProjectDocumentsUpdates PerformQuantitativeRiskAnalysis(
			RiskManagementPlan rmp,
			CostManagementPlan cmp,
			ScheduleManagementPlan smp,
			RiskRegister rr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new ProjectDocumentsUpdates ();
		}

		class PlanRiskResponsesResult
		{
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
		}
		PlanRiskResponsesResult PlanRiskResponses(
			RiskManagementPlan rmp,
			RiskRegister rr)
		{
			return new PlanRiskResponsesResult ();
		}

		class PlanProcurementManagementResult
		{
			ProcurementManagementPlan pmp;
			ProcurementStatementOfWork psow;
			ProcurementDocuments pd;
			SourceSelectionCriteria ssc;
			MakeOrBuyDecisions mobd;
			ChangeRequests cr;
			ProjectDocumentsUpdates pds;
		}
		PlanProcurementManagementResult PlanProcurementManagement(
			ProjectManagementPlan pmp,
			RequirementsDocumentation rd,
			RiskRegister rr,
			ActivityResourceRequirements arr,
			ProjectSchedule ps,
			ActivityCostEstimates ace,
			StakeholderRegister sr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new PlanProcurementManagementResult ();
		}

		class PlanStakeholderManagementResult
		{
			StakeholderManagementPlan smp;
			ProjectDocumentsUpdates pdu;
		}
		PlanStakeholderManagementResult PlanStakeholderManagement(
			ProjectManagementPlan pmp,
			StakeholderRegister sr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new PlanStakeholderManagementResult ();
		}




		public virtual void Executing()
		{
			Console.WriteLine("> > > Executing...");
			DirectAndManageProjectWork(
				m_ProjectManagementPlan,
				m_ApprovedChangeRequests,
				m_EnterpriseEnvironmentalFactors,
				m_OrganizationalProcessAssets);
			PerformQualityAssurance(
				m_QualityManagementPlan,
				m_ProcessImprovementPlan,
				m_QualityMetrics,
				m_QualityControlMeasurements,
				m_ProjectDocuments);
			AcquireProjectTeam(
				m_HumanResourceManagementPlan,
				m_EnterpriseEnvironmentalFactors,
				m_OrganizationalProcessAssets);
			DevelopProjectTeam(
				m_HumanResourceManagementPlan,
				m_ProjectStaffAssignments,
				m_ResourceCalendars);
			ManageProjectTeam(
				m_HumanResourceManagementPlan,
				m_ProjectStaffAssignments,
				m_TeamPerformanceAssessments,
				m_IssueLog,
				m_WorkPerformanceReports,
				m_OrganizationalProcessAssets);
			ManageCommunications(
				m_CommunicationsManagementPlan,
				m_WorkPerformanceReports,
				m_EnterpriseEnvironmentalFactors,
				m_OrganizationalProcessAssets);
			ConductProcurements(
				m_ProcurementManagementPlan,
				m_ProcurementDocuments,
				m_SourceSelectionCriteria,
				m_SellerProposals,
				m_ProjectDocuments,
				m_MakeOrBuyDecisions,
				m_ProcurementStatementOfWork,
				m_OrganizationalProcessAssets);
			ManageStakeholderEngagement(
				m_StakeholderManagementPlan,
				m_CommunicationsManagementPlan,
				m_ChangeLog,
				m_OrganizationalProcessAssets);
			
		}

		class DirectAndManageProjectWorkResult
		{
			Deliverables d;
			WorkPerformanceData wpd;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
		}
		DirectAndManageProjectWorkResult DirectAndManageProjectWork(
			ProjectManagementPlan pmp,
			ApprovedChangeRequests cr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new DirectAndManageProjectWorkResult();
		}

		class PerformQualityAssuranceResult
		{
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		PerformQualityAssuranceResult PerformQualityAssurance(
			QualityManagementPlan qmp,
			ProcessImprovementPlan pip,
			QualityMetrics qm,
			QualityControlMeasurements qcm,
			ProjectDocuments pd)
		{
			return new PerformQualityAssuranceResult();
		}

		class AcquireProjectTeamResult
		{
			ProjectStaffAssignments psa;
			ResourceCalendars rc;
			ProjectManagementPlanUpdates pmpu;
		}
		AcquireProjectTeamResult AcquireProjectTeam(
			HumanResourceManagementPlan hrmp,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new AcquireProjectTeamResult();
		}

		class DevelopProjectTeamResult
		{
			TeamPerformanceAssessments tpa;
			EnterpriseEnvironmentalFactorsUpdates eefu;
		}
		DevelopProjectTeamResult DevelopProjectTeam(
			HumanResourceManagementPlan hrmp,
			ProjectStaffAssignments psa,
			ResourceCalendars rc)
		{
			return new DevelopProjectTeamResult();
		}

		class ManageProjectTeamResult
		{
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			EnterpriseEnvironmentalFactorsUpdates eefu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ManageProjectTeamResult ManageProjectTeam(
			HumanResourceManagementPlan hrmp,
			ProjectStaffAssignments psa,
			TeamPerformanceAssessments tpa,
			IssueLog il,
			WorkPerformanceReports wpr,
			OrganizationalProcessAssets opa)
		{
			return new ManageProjectTeamResult();
		}

		class ManageCommunicationsResult
		{
			ProjectCommunications pc;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ManageCommunicationsResult ManageCommunications(
			CommunicationsManagementPlan cmp,
			WorkPerformanceReports wpr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new ManageCommunicationsResult();
		}

		class ConductProcurementsResult
		{
			SelectedSellers ss;
			Agreements a;
			ResourceCalendar rc;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
		}
		ConductProcurementsResult ConductProcurements(
			ProcurementManagementPlan pmp,
			ProcurementDocuments pd,
			SourceSelectionCriteria ssc,
			SellerProposals sp,
			ProjectDocuments pjd,
			MakeOrBuyDecisions mobd,
			ProcurementStatementOfWork psow,
			OrganizationalProcessAssets opa)
		{
			return new ConductProcurementsResult();
		}

		class ManageStakeholderEngagementResult
		{
			IssueLog il;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ManageStakeholderEngagementResult ManageStakeholderEngagement(
			StakeholderManagementPlan smp,
			CommunicationsManagementPlan cmp,
			ChangeLog cl,
			OrganizationalProcessAssets opa)
		{
			return new ManageStakeholderEngagementResult();
		}





		public virtual void MonitoringAndControlling()
		{
			Console.WriteLine("> > > MonitoringAndControlling...");
			MonitorAndControlProjectWork(
				m_ProjectManagementPlan,
				m_ScheduleForecasts,
				m_CostForecasts,
				m_ValidatedChanges,
				m_WorkPerformanceInformation,
				m_EnterpriseEnvironmentalFactors,
				m_OrganizationalProcessAssets);
			PerformIntegratedChangeControl(
				m_ProjectManagementPlan,
				m_WorkPerformanceReports,
				m_ChangeRequests,
				m_EnterpriseEnvironmentalFactors,
				m_OrganizationalProcessAssets);
			ValidateScope(
				m_ProjectManagementPlan,
				m_RequirementsDocumentation,
				m_RequirementsTraceabilityMatrix,
				m_VerifiedDeliverables,
				m_WorkPerformanceData);
			ControlScope(
				m_ProjectManagementPlan,
				m_RequirementsDocumentation,
				m_RequirementsTraceabilityMatrix,
				m_WorkPerformanceData,
				m_OrganizationalProcessAssets);
			ControlSchedule(
				m_ProjectManagementPlan,
				m_ProjectSchedule,
				m_WorkPerformanceData,
				m_ProjectCalendars,
				m_ScheduleData,
				m_OrganizationalProcessAssets);
			ControlCosts(
				m_ProjectManagementPlan,
				m_ProjectFundingRequirements,
				m_WorkPerformanceData,
				m_OrganizationalProcessAssets);
			ControlQuality(
				m_ProjectManagementPlan,
				m_QualityMetrics,
				m_QualityChecklists,
				m_WorkPerformanceData,
				m_ApprovedChangeRequests,
				m_Deliverables,
				m_ProjectDocuments,
				m_OrganizationalProcessAssets);
			ControlCommunications(
				m_ProjectManagementPlan,
				m_ProjectCommunications,
				m_IssueLog,
				m_WorkPerformanceData,
				m_OrganizationalProcessAssets);
			ControlRisks(
				m_ProjectManagementPlan,
				m_RiskRegister,
				m_WorkPerformanceData,
				m_WorkPerformanceReports);
			ControlProcurements(
				m_ProjectManagementPlan,
				m_ProcurementDocuments,
				m_Agreements,
				m_ApprovedChangeRequests,
				m_WorkPerformanceReports,
				m_WorkPerformanceData);
			ControlStakeholderEngagement(
				m_ProjectManagementPlan,
				m_IssueLog,
				m_WorkPerformanceData,
				m_ProjectDocuments);
			
		}

		class MonitorAndControlProjectWorkResult
		{
			ChangeRequests cr;
			WorkPerformanceReports wpr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
		}
		MonitorAndControlProjectWorkResult MonitorAndControlProjectWork(
			ProjectManagementPlan pmp,
			ScheduleForecasts sf,
			CostForecasts cf,
			ValidatedChanges vc,
			WorkPerformanceInformation wpi,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new MonitorAndControlProjectWorkResult();
		}

		class PerformIntegratedChangeControlResult
		{
			ApprovedChangeRequests cr;
			ChangeLog cl;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
		}
		PerformIntegratedChangeControlResult PerformIntegratedChangeControl(
			ProjectManagementPlan pmp,
			WorkPerformanceReports wpr,
			ChangeRequests cr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new PerformIntegratedChangeControlResult();
		}

		class ValidateScopeResult
		{
			AcceptedDeliverables d;
			ChangeRequests cr;
			WorkPerformanceInformation wpi;
			ProjectDocumentsUpdates pdu;
		}
		ValidateScopeResult ValidateScope(
			ProjectManagementPlan pmp,
			RequirementsDocumentation rd,
			RequirementsTraceabilityMatrix rtm,
			VerifiedDeliverables d,
			WorkPerformanceData wpd)
		{
			return new ValidateScopeResult();
		}

		class ControlScopeResult
		{
			WorkPerformanceInformation wpi;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlScopeResult ControlScope(
			ProjectManagementPlan pmp,
			RequirementsDocumentation rd,
			RequirementsTraceabilityMatrix rtm,
			WorkPerformanceData wpd,
			OrganizationalProcessAssets opa)
		{
			return new ControlScopeResult();
		}

		class ControlScheduleResult
		{
			WorkPerformanceInformation wpi;
			ScheduleForecasts sf;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlScheduleResult ControlSchedule(
			ProjectManagementPlan pmp,
			ProjectSchedule ps,
			WorkPerformanceData wpd,
			ProjectCalendars pc,
			ScheduleData sd,
			OrganizationalProcessAssets opa)
		{
			return new ControlScheduleResult();
		}

		class ControlCostsResult
		{
			WorkPerformanceInformation wpi;
			CostForecasts cf;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlCostsResult ControlCosts(
			ProjectManagementPlan pmp,
			ProjectFundingRequirements pfr,
			WorkPerformanceData wpd,
			OrganizationalProcessAssets opa)
		{
			return new ControlCostsResult();
		}

		class ControlQualityResult
		{
			QualityControlMeasurements qcm;
			ValidatedChanges vc;
			VerifiedDeliverables d;
			WorkPerformanceInformation wpi;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlQualityResult ControlQuality(
			ProjectManagementPlan pmp,
			QualityMetrics qm,
			QualityChecklists qc,
			WorkPerformanceData wpd,
			ApprovedChangeRequests cr,
			Deliverables d,
			ProjectDocuments pjd,
			OrganizationalProcessAssets opa)
		{
			return new ControlQualityResult();
		}

		class ControlCommunicationsResult
		{
			WorkPerformanceInformation wpi;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlCommunicationsResult ControlCommunications(
			ProjectManagementPlan pmp,
			ProjectCommunications pc,
			IssueLog il,
			WorkPerformanceData wpd,
			OrganizationalProcessAssets opa)
		{
			return new ControlCommunicationsResult();
		}

		class ControlRisksResult
		{
			WorkPerformanceInformation wpi;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlRisksResult ControlRisks(
			ProjectManagementPlan pmp,
			RiskRegister rr,
			WorkPerformanceData wpd,
			WorkPerformanceReports wpr)
		{
			return new ControlRisksResult();
		}

		class ControlProcurementsResult
		{
			WorkPerformanceInformation wpi;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlProcurementsResult ControlProcurements(
			ProjectManagementPlan pmp,
			ProcurementDocuments pd,
			Agreements a,
			ApprovedChangeRequests cr,
			WorkPerformanceReports wpr,
			WorkPerformanceData wpd)
		{
			return new ControlProcurementsResult();
		}

		class ControlStakeholderEngagementResult
		{
			WorkPerformanceInformation wpi;
			ChangeRequests cr;
			ProjectManagementPlanUpdates pmpu;
			ProjectDocumentsUpdates pdu;
			OrganizationalProcessAssetsUpdates opau;
		}
		ControlStakeholderEngagementResult ControlStakeholderEngagement(
			ProjectManagementPlan pmp,
			IssueLog il,
			WorkPerformanceData wpd,
			ProjectDocuments pd)
		{
			return new ControlStakeholderEngagementResult();
		}


		public virtual void Closing()
		{
			Console.WriteLine("> > > Closing...");

			CloseProjectOrPhase(m_ProjectManagementPlan, m_AcceptedDeliverables, m_OrganizationalProcessAssets);
			CloseProcurements (m_ProjectManagementPlan, m_ProcurementDocuments);
		}

		class CloseProjectOrPhaseResult
		{
			FinalProductServiceOrResultTransition fpsort;
			OrganizationalProcessAssetsUpdates opau;
		}
		CloseProjectOrPhaseResult CloseProjectOrPhase(
			ProjectManagementPlan pmp,
			AcceptedDeliverables ad,
			OrganizationalProcessAssets op)
		{
			return new CloseProjectOrPhaseResult();
		}

		class CloseProcurementsResult
		{
			ClosedProcurements cp;
			OrganizationalProcessAssetsUpdates opau;
		}
		CloseProcurementsResult CloseProcurements(
			ProjectManagementPlan pmp,
			ProcurementDocuments pd)
		{
			return new CloseProcurementsResult();
		}

		public void Processing()
		{
			this.Initiating();
			this.Planning();
			this.Executing();
			this.MonitoringAndControlling();
			this.Closing();
		}


	};

	class TestPM : ProjectManagement
	{
		
	}

	class ProgrammingPM : ProjectManagement
	{
	}

	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");

			ProjectManagement pm = new TestPM();
			pm.Processing();
		}
	}
}
