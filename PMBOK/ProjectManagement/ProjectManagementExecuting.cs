// ProjectManagementExecuting.cs
namespace PMBOK
{
	using System;
	using System.Diagnostics;

	using PMBOK.Processes;

	public class ProjectManagementExecuting
	{
		public ProjectManagement ProjectManagement;
		private ProjectManagement pm
		{
			get
			{
				return this.ProjectManagement;
			}
		}

		public ProjectManagementExecuting(ProjectManagement pm)
		{
			this.ProjectManagement = pm;
		}

		public virtual void Run()
		{
			Console.WriteLine("> > > Executing...");

			this.DirectAndManageProjectWork(this.pm.m_ProjectManagementPlan, this.pm.m_ApprovedChangeRequests, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PerformQualityAssurance(this.pm.m_QualityManagementPlan, this.pm.m_ProcessImprovementPlan, this.pm.m_QualityMetrics, this.pm.m_QualityControlMeasurements, this.pm.m_ProjectDocuments);
			this.AcquireProjectTeam(this.pm.m_HumanResourceManagementPlan, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.DevelopProjectTeam(this.pm.m_HumanResourceManagementPlan, this.pm.m_ProjectStaffAssignments, this.pm.m_ResourceCalendars);
			this.ManageProjectTeam(this.pm.m_HumanResourceManagementPlan, this.pm.m_ProjectStaffAssignments, this.pm.m_TeamPerformanceAssessments, this.pm.m_IssueLog, this.pm.m_WorkPerformanceReports, this.pm.m_OrganizationalProcessAssets);
			this.ManageCommunications(this.pm.m_CommunicationsManagementPlan, this.pm.m_WorkPerformanceReports, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.ConductProcurements(this.pm.m_ProcurementManagementPlan, this.pm.m_ProcurementDocuments, this.pm.m_SourceSelectionCriteria, this.pm.m_SellerProposals, this.pm.m_ProjectDocuments, this.pm.m_MakeOrBuyDecisions, this.pm.m_ProcurementStatementOfWork, this.pm.m_OrganizationalProcessAssets);
			this.ManageStakeholderEngagement(this.pm.m_StakeholderManagementPlan, this.pm.m_CommunicationsManagementPlan, this.pm.m_ChangeLog, this.pm.m_OrganizationalProcessAssets);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(cr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(qmp != null);
			Debugger.Assert(pip != null);
			Debugger.Assert(qm != null);
			Debugger.Assert(qcm != null);
			Debugger.Assert(pd != null);
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
			Debugger.Assert(hrmp != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(hrmp != null);
			Debugger.Assert(psa != null);
			Debugger.Assert(rc != null);
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
			Debugger.Assert(hrmp != null);
			Debugger.Assert(psa != null);
			Debugger.Assert(tpa != null);
			Debugger.Assert(il != null);
			Debugger.Assert(wpr != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(cmp != null);
			Debugger.Assert(wpr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(pd != null);
			Debugger.Assert(ssc != null);
			Debugger.Assert(sp != null);
			Debugger.Assert(pjd != null);
			Debugger.Assert(mobd != null);
			Debugger.Assert(psow != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(smp != null);
			Debugger.Assert(cmp != null);
			Debugger.Assert(cl != null);
			Debugger.Assert(opa != null);
			return new ManageStakeholderEngagementResult();
		}

	}
}