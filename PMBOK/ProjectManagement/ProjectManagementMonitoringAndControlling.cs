
// ProjectManagementMonitoringAndControlling.cs
namespace PMBOK
{
	using System;

	using PMBOK.Processes;

	public class ProjectManagementMonitoringAndControlling
	{
		public ProjectManagement ProjectManagement;
		private ProjectManagement pm
		{
			get
			{
				return this.ProjectManagement;
			}
		}

		public ProjectManagementMonitoringAndControlling(ProjectManagement pm)
		{
			this.ProjectManagement = pm;
		}

		public virtual void Run()
		{
			Console.WriteLine("> > > MonitoringAndControlling...");
			this.MonitorAndControlProjectWork(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_ScheduleForecasts,
				this.pm.m_CostForecasts,
				this.pm.m_ValidatedChanges,
				this.pm.m_WorkPerformanceInformation,
				this.pm.m_EnterpriseEnvironmentalFactors,
				this.pm.m_OrganizationalProcessAssets);
			this.PerformIntegratedChangeControl(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_WorkPerformanceReports,
				this.pm.m_ChangeRequests,
				this.pm.m_EnterpriseEnvironmentalFactors,
				this.pm.m_OrganizationalProcessAssets);
			this.ValidateScope(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_RequirementsDocumentation,
				this.pm.m_RequirementsTraceabilityMatrix,
				this.pm.m_VerifiedDeliverables,
				this.pm.m_WorkPerformanceData);
			this.ControlScope(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_RequirementsDocumentation,
				this.pm.m_RequirementsTraceabilityMatrix,
				this.pm.m_WorkPerformanceData,
				this.pm.m_OrganizationalProcessAssets);
			this.ControlSchedule(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_ProjectSchedule,
				this.pm.m_WorkPerformanceData,
				this.pm.m_ProjectCalendars,
				this.pm.m_ScheduleData,
				this.pm.m_OrganizationalProcessAssets);
			this.ControlCosts(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_ProjectFundingRequirements,
				this.pm.m_WorkPerformanceData,
				this.pm.m_OrganizationalProcessAssets);
			this.ControlQuality(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_QualityMetrics,
				this.pm.m_QualityChecklists,
				this.pm.m_WorkPerformanceData,
				this.pm.m_ApprovedChangeRequests,
				this.pm.m_Deliverables,
				this.pm.m_ProjectDocuments,
				this.pm.m_OrganizationalProcessAssets);
			this.ControlCommunications(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_ProjectCommunications,
				this.pm.m_IssueLog,
				this.pm.m_WorkPerformanceData,
				this.pm.m_OrganizationalProcessAssets);
			this.ControlRisks(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_RiskRegister,
				this.pm.m_WorkPerformanceData,
				this.pm.m_WorkPerformanceReports);
			this.ControlProcurements(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_ProcurementDocuments,
				this.pm.m_Agreements,
				this.pm.m_ApprovedChangeRequests,
				this.pm.m_WorkPerformanceReports,
				this.pm.m_WorkPerformanceData);
			this.ControlStakeholderEngagement(
				this.pm.m_ProjectManagementPlan,
				this.pm.m_IssueLog,
				this.pm.m_WorkPerformanceData,
				this.pm.m_ProjectDocuments);

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
 
	}
}