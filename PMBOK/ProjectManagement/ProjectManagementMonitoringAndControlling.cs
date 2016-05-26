
// ProjectManagementMonitoringAndControlling.cs
namespace PMBOK
{
	using System;
	using System.Diagnostics;

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

			// 监控的过程就是 找问题 的过程
			// 监控是一个比较容易理解的过程，将当前执行过程中产生的结果输入到监控系统，监控系统用各种方法进行分析，得到结果是否需要调整

			this.MonitorAndControlProjectWork(this.pm.m_ProjectManagementPlan, this.pm.m_ScheduleForecasts, this.pm.m_CostForecasts, this.pm.m_ValidatedChanges, this.pm.m_WorkPerformanceInformation, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.PerformIntegratedChangeControl(this.pm.m_ProjectManagementPlan, this.pm.m_WorkPerformanceReports, this.pm.m_ChangeRequests, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			
			// 控制的过程中都要使用WORK PERFORMANCE DATA，根据PERFORMANCE来决定是否要调整相关事务
			// 从不同的角度（知识领域）出发，对相关数据进行检查
			this.ControlScope(this.pm.m_ProjectManagementPlan, this.pm.m_RequirementsDocumentation, this.pm.m_RequirementsTraceabilityMatrix, this.pm.m_WorkPerformanceData, this.pm.m_OrganizationalProcessAssets);
			this.ControlSchedule(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectSchedule, this.pm.m_WorkPerformanceData, this.pm.m_ProjectCalendars, this.pm.m_ScheduleData, this.pm.m_OrganizationalProcessAssets);
			this.ControlCosts(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectFundingRequirements, this.pm.m_WorkPerformanceData, this.pm.m_OrganizationalProcessAssets);
			this.ControlQuality(this.pm.m_ProjectManagementPlan, this.pm.m_QualityMetrics, this.pm.m_QualityChecklists, this.pm.m_WorkPerformanceData, this.pm.m_ApprovedChangeRequests, this.pm.m_Deliverables, this.pm.m_ProjectDocuments, this.pm.m_OrganizationalProcessAssets);
			this.ControlCommunications(this.pm.m_ProjectManagementPlan, this.pm.m_ProjectCommunications, this.pm.m_IssueLog, this.pm.m_WorkPerformanceData, this.pm.m_OrganizationalProcessAssets);
			this.ControlRisks(this.pm.m_ProjectManagementPlan, this.pm.m_RiskRegister, this.pm.m_WorkPerformanceData, this.pm.m_WorkPerformanceReports);
			this.ControlProcurements(this.pm.m_ProjectManagementPlan, this.pm.m_ProcurementDocuments, this.pm.m_Agreements, this.pm.m_ApprovedChangeRequests, this.pm.m_WorkPerformanceReports, this.pm.m_WorkPerformanceData);
			this.ControlStakeholderEngagement(this.pm.m_ProjectManagementPlan, this.pm.m_IssueLog, this.pm.m_WorkPerformanceData, this.pm.m_ProjectDocuments);

			// 这步不应该在这里，应该是本过程组最后一个步骤
			this.ValidateScope(this.pm.m_ProjectManagementPlan, this.pm.m_RequirementsDocumentation, this.pm.m_RequirementsTraceabilityMatrix, this.pm.m_VerifiedDeliverables, this.pm.m_WorkPerformanceData);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(sf != null);
			Debugger.Assert(cf != null);
			Debugger.Assert(vc != null);
			Debugger.Assert(wpi != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(wpr != null);
			Debugger.Assert(cr != null);
			Debugger.Assert(eef != null);
			Debugger.Assert(opa != null);
			return new PerformIntegratedChangeControlResult();
		}

		class ValidateScopeResult
		{
			AcceptedDeliverables ad;
			ChangeRequests cr;
			WorkPerformanceInformation wpi;
			ProjectDocumentsUpdates pdu;
		}
		ValidateScopeResult ValidateScope(
			ProjectManagementPlan pmp,
			RequirementsDocumentation rd,
			RequirementsTraceabilityMatrix rtm,
			VerifiedDeliverables vd,
			WorkPerformanceData wpd)
		{
			// 通过 计划、需求、结果、过程   得出 可以接受的可交付的成果
			Debugger.Assert(pmp != null);
			Debugger.Assert(rd != null);
			Debugger.Assert(rtm != null);
			Debugger.Assert(vd != null);
			Debugger.Assert(wpd != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(rd != null);
			Debugger.Assert(rtm != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(opa != null);

			// IMPORTANT!!! TOOLS
// 			Regression analysis
// 			Grouping methods
// 			Causal analysis
// 			Root cause analysis
// 			Forecasting methods (e.g., time series, scenario building, simulation, etc.)
// 			Failure mode and effect analysis (FMEA)
// 			Fault tree analysis (FTA)
// 			Reserve analysis
// 			Trend analysis
// 			Earned value management
// 			Variance analysis

			// Variance Analysis
			// var variance = ScopeBaseline - WorkPerformanceData;
			// (这需要A与B的格式是一至的，要不然无法进行比较)

			// root cause analysis (RCA)
			//  1.why? -> why? -> why? -> why? -> why?
			//  2.fishbone diagram
			//  http://wenku.baidu.com searching "Root Cause Analysis Process"

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
			Debugger.Assert(pmp != null);
			Debugger.Assert(ps != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(sd != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(pfr != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(qm != null);
			Debugger.Assert(qc != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(cr != null);
			Debugger.Assert(d != null);
			Debugger.Assert(pjd != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(pc != null);
			Debugger.Assert(il != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(opa != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(rr != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(wpr != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(pd != null);
			Debugger.Assert(a != null);
			Debugger.Assert(cr != null);
			Debugger.Assert(wpr != null);
			Debugger.Assert(wpd != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(il != null);
			Debugger.Assert(wpd != null);
			Debugger.Assert(pd != null);
			return new ControlStakeholderEngagementResult();
		}

	}
}