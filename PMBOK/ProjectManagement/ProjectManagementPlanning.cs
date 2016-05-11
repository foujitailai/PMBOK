namespace PMBOK
{
	using System;
	using System.Diagnostics;
	using System.Reflection;

	using PMBOK.Processes;

	public class ProjectManagementPlanning
	{
		public ProjectManagement ProjectManagement;
		private ProjectManagement pm
		{
			get
			{
				return this.ProjectManagement;
			}
		}

		public ProjectManagementPlanning(ProjectManagement pm)
		{
			this.ProjectManagement = pm;
		}

		public virtual void Run()
		{
			Console.WriteLine("> > > Planning...");

			// ========== SCOPE ==========
			this.DevelopProjectManagementPlan(this.pm.m_ProjectCharter, this.pm.m_OutputsFromOtherProcesses, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PlanScopeManagement(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectCharter, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.CollectRequirements(this.pm.m_ScopeManagementPlan, this.pm.m_RequirementsManagementPlan, this.pm.m_StakeholderManagementPlan, this.pm.m_ProjectCharter, this.pm.m_StakeholderRegister);
			this.DefineScope(this.pm.m_ScopeManagementPlan, this.pm.m_ProjectCharter, this.pm.m_RequirementsDocumentation, this.pm.m_OrganizationalProcessAssets);
			this.CreateWBS(this.pm.m_ScopeManagementPlan, this.pm.m_ProjectScopeStatement, this.pm.m_RequirementsDocumentation, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PlanScheduleManagement(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectCharter, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.DefineActivities(this.pm.m_ScheduleManagementPlan, this.pm.m_ScopeBaseline, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.SequenceActivities(this.pm.m_ScheduleManagementPlan, this.pm.m_ActivityList, this.pm.m_ActivityAttributes, this.pm.m_MilestoneList, this.pm.m_ProjectScopeStatement, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.EstimateActivityResources(this.pm.m_ScheduleManagementPlan, this.pm.m_ActivityList, this.pm.m_ActivityAttributes, this.pm.m_ResourceCalendars, this.pm.m_RiskRegister, this.pm.m_ActivityCostEstimates, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			// TIME
			this.EstimateActivityDurations(this.pm.m_ScheduleManagementPlan, this.pm.m_ActivityList, this.pm.m_ActivityAttributes, this.pm.m_ActivityResourceRequirements, this.pm.m_ResourceCalendars, this.pm.m_ProjectScopeStatement, this.pm.m_RiskRegister, this.pm.m_ResourceBreakdownStructure, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			// important, the activities are planed.
			this.DevelopSchedule(this.pm.m_ScheduleManagementPlan, this.pm.m_ActivityList, this.pm.m_ActivityAttributes, this.pm.m_ProjectScheduleNetworkDiagrams, this.pm.m_ActivityResourceRequirements, this.pm.m_ResourceCalendars, this.pm.m_ActivityDurationEstimates, this.pm.m_ProjectScopeStatement, this.pm.m_RiskRegister, this.pm.m_ProjectStaffAssignments, this.pm.m_ResourceBreakdownStructure, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);

			// ========== COST ========
			this.PlanCostManagement(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectCharter, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.EstimateCosts(this.pm.m_CostManagementPlan, this.pm.m_HumanResourceManagementPlan, this.pm.m_ScopeBaseline, this.pm.m_ProjectSchedule, this.pm.m_RiskRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			// cost are planed
			this.DetermineBudget(this.pm.m_CostManagementPlan, this.pm.m_ScopeBaseline, this.pm.m_ActivityCostEstimates, this.pm.m_BasisOfEstimates, this.pm.m_ProjectSchedule, this.pm.m_ResourceCalendars, this.pm.m_RiskRegister, this.pm.m_Agreements, this.pm.m_OrganizationalProcessAssets);

			// ========== QUALITY ===========
			this.PlanQualityManagement(this.pm.m_ProjectManagementPlan, this.pm.m_StakeholderRegister, this.pm.m_RiskRegister, this.pm.m_RequirementsDocumentation, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);

			// ========== HUMAN RESOURCE =======
			this.PlanHumanResourceManagement(this.pm.m_ProjectManagementPlan, this.pm.m_ActivityResourceRequirements, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);

			// ========== COMMUNICATION =======
			this.PlanCommunicationsManagement(this.pm.m_ProjectManagementPlan, this.pm.m_StakeholderRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);

			// ========== RISK ========
			this.PlanRiskManagement(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectCharter, this.pm.m_StakeholderRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.IdentifyRisks(this.pm.m_RiskManagementPlan, this.pm.m_CostManagementPlan, this.pm.m_ScheduleManagementPlan, this.pm.m_QualityManagementPlan, this.pm.m_HumanResourceManagementPlan, this.pm.m_ScopeBaseline, this.pm.m_ActivityCostEstimates, this.pm.m_ActivityDurationEstimates, this.pm.m_StakeholderRegister, this.pm.m_ProjectDocuments, this.pm.m_ProcurementDocuments, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PerformQualitativeRiskAnalysis(this.pm.m_RiskManagementPlan, this.pm.m_ScopeBaseline, this.pm.m_RiskRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PerformQuantitativeRiskAnalysis(this.pm.m_RiskManagementPlan, this.pm.m_CostManagementPlan, this.pm.m_ScheduleManagementPlan, this.pm.m_RiskRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PlanRiskResponses(this.pm.m_RiskManagementPlan, this.pm.m_RiskRegister);

			// ========== PROCUREMENT ======
			this.PlanProcurementManagement(this.pm.m_ProjectManagementPlan, this.pm.m_RequirementsDocumentation, this.pm.m_RiskRegister, this.pm.m_ActivityResourceRequirements, this.pm.m_ProjectSchedule, this.pm.m_ActivityCostEstimates, this.pm.m_StakeholderRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);

			// ========== STAKEHOLDER ======
			this.PlanStakeholderManagement(this.pm.m_ProjectManagementPlan, this.pm.m_StakeholderRegister, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
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
			Debugger.Assert(pc != null);
			Debugger.Assert(ofop != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new ProjectManagementPlan();
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(op != null);

			return new PlanScopeManagementResult();
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
			Debugger.Assert(smp != null);
			Debugger.Assert(rmp != null);
			Debugger.Assert(shmp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(sr != null);
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
			Debugger.Assert(smp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(rd != null);
			Debugger.Assert(opa != null);
			return new DefineScopeResult();
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
			Debugger.Assert(smp != null);
			Debugger.Assert(pss != null);
			Debugger.Assert(rd != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new CreateWBSResult();
		}

		ScheduleManagementPlan PlanScheduleManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			Debugger.Assert(pmp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new ScheduleManagementPlan();
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
			Debugger.Assert(smp != null);
			Debugger.Assert(sb != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new DefineActivitiesResult();
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
			Debugger.Assert(smp != null);
			Debugger.Assert(al != null);
			Debugger.Assert(aa != null);
			Debugger.Assert(ml != null);
			Debugger.Assert(pss != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new SequenceActivitiesResult();
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
			Debugger.Assert(smp != null);
			Debugger.Assert(al != null);
			Debugger.Assert(aa != null);
			Debugger.Assert(rc != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(ace != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new EstimateActivityResourcesResult();
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
			// RiskRegister，当前函数（EstimateActivityDurations）引用了这个文档，
			//  但是这个文档的生成函数（IdentifyRisks），又引用了当前函数（EstimateActivityDurations）生成的ActivityDurationEstimates，
			//  形成了逻辑死锁状态，无法达成目标，How can I do it?


			Debugger.Assert(smp != null);
			Debugger.Assert(al != null);
			Debugger.Assert(aa != null);
			Debugger.Assert(arr != null);
			Debugger.Assert(rc != null);
			Debugger.Assert(pss != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(rbs != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);


			return new EstimateActivityDurationsResult();
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
			Debugger.Assert(smp != null);
			Debugger.Assert(al != null);
			Debugger.Assert(aa != null);
			Debugger.Assert(psnd != null);
			Debugger.Assert(arr != null);
			Debugger.Assert(rc != null);
			Debugger.Assert(ade != null);
			Debugger.Assert(pss != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(psa != null);
			Debugger.Assert(rbs != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new DevelopScheduleResult();
		}

		CostManagementPlan PlanCostManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			Debugger.Assert(pmp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new CostManagementPlan();
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
			Debugger.Assert(cmp != null);
			Debugger.Assert(hrmp != null);
			Debugger.Assert(sb != null);
			Debugger.Assert(ps != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new EstimateCostsResult();
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
			Debugger.Assert(cmp != null);
			Debugger.Assert(sb != null);
			Debugger.Assert(ace != null);
			Debugger.Assert(boe != null);
			Debugger.Assert(ps != null);
			Debugger.Assert(rc != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(a != null);
			Debugger.Assert(opa != null);
			return new DetermineBudgetResult();
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(sr != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(rd != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new PlanQualityManagementResult();
		}

		HumanResourceManagementPlan PlanHumanResourceManagement(
			ProjectManagementPlan pmp,
			ActivityResourceRequirements arr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			Debugger.Assert(pmp != null);
			Debugger.Assert(arr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new HumanResourceManagementPlan();
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(sr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new PlanCommunicationsManagementResult();
		}

		RiskManagementPlan PlanRiskManagement(
			ProjectManagementPlan pmp,
			ProjectCharter pc,
			StakeholderRegister sr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			Debugger.Assert(pmp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(sr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new RiskManagementPlan();
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
			Debugger.Assert(rmp != null);
			Debugger.Assert(cmp != null);
			Debugger.Assert(smp != null);
			Debugger.Assert(qmp != null);
			Debugger.Assert(hrmp != null);
			Debugger.Assert(sb != null);
			Debugger.Assert(ace != null);
			Debugger.Assert(ade != null);
			Debugger.Assert(sr != null);
			Debugger.Assert(pjd != null);
			Debugger.Assert(pd != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new RiskRegister();
		}

		ProjectDocumentsUpdates PerformQualitativeRiskAnalysis(
			RiskManagementPlan rmp,
			ScopeBaseline sb,
			RiskRegister rr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			Debugger.Assert(rmp != null);
			Debugger.Assert(sb != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new ProjectDocumentsUpdates();
		}

		ProjectDocumentsUpdates PerformQuantitativeRiskAnalysis(
			RiskManagementPlan rmp,
			CostManagementPlan cmp,
			ScheduleManagementPlan smp,
			RiskRegister rr,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			Debugger.Assert(rmp != null);
			Debugger.Assert(cmp != null);
			Debugger.Assert(smp != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new ProjectDocumentsUpdates();
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
			Debugger.Assert(rmp != null);
			Debugger.Assert(rr != null);
			return new PlanRiskResponsesResult();
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(rd != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(arr != null);
			Debugger.Assert(ps != null);
			Debugger.Assert(ace != null);
			Debugger.Assert(sr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new PlanProcurementManagementResult();
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(sr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new PlanStakeholderManagementResult();
		}

	}
}