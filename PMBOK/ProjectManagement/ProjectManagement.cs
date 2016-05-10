namespace PMBOK
{
	using System;

	using PMBOK.Processes;

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
	public class ProjectManagement
	{
		public ProjectCharter	m_ProjectCharter;
		public ProjectStatementOfWork m_ProjectStatementOfWork;
		public BusinessCase m_BusinessCase;
		public Agreements m_Agreements;
		public EnterpriseEnvironmentalFactors m_EnterpriseEnvironmentalFactors;
		public OrganizationalProcessAssets m_OrganizationalProcessAssets;
		public StakeholderRegister m_StakeholderRegister;
		public ProcurementDocuments m_ProcurementDocuments;
		public ProjectManagementPlan m_ProjectManagementPlan;
		public OutputsFromOtherProcesses m_OutputsFromOtherProcesses = new OutputsFromOtherProcesses();
		public ScopeManagementPlan m_ScopeManagementPlan;
		public RequirementsManagementPlan m_RequirementsManagementPlan;
		public RequirementsDocumentation m_RequirementsDocumentation;
		public RequirementsTraceabilityMatrix m_RequirementsTraceabilityMatrix;
		public StakeholderManagementPlan m_StakeholderManagementPlan;
		public ProjectScopeStatement m_ProjectScopeStatement;
		public ProjectDocumentsUpdates m_ProjectDocumentsUpdates;
		public ScopeBaseline m_ScopeBaseline;
		public ScheduleManagementPlan m_ScheduleManagementPlan;
		public ActivityList m_ActivityList;
		public ActivityAttributes m_ActivityAttributes;
		public MilestoneList m_MilestoneList;
		public ProjectScheduleNetworkDiagrams m_ProjectScheduleNetworkDiagrams;
		public ActivityResourceRequirements m_ActivityResourceRequirements;
		public ResourceBreakdownStructure m_ResourceBreakdownStructure;
		public ResourceCalendars m_ResourceCalendars;
		public RiskRegister m_RiskRegister;
		public ActivityCostEstimates m_ActivityCostEstimates;
		public ActivityDurationEstimates m_ActivityDurationEstimates;
		public ScheduleBaseline m_ScheduleBaseline;
		public ProjectSchedule m_ProjectSchedule;
		public ScheduleData m_ScheduleData;
		public ProjectCalendars m_ProjectCalendars;
		public ProjectManagementPlanUpdates m_ProjectManagementPlanUpdates;
		public ProjectStaffAssignments m_ProjectStaffAssignments;
		public CostManagementPlan m_CostManagementPlan;
		public BasisOfEstimates m_BasisOfEstimates;
		public HumanResourceManagementPlan m_HumanResourceManagementPlan;
		public CostBaseline m_CostBaseline;
		public ProjectFundingRequirements m_ProjectFundingRequirements;
		public QualityManagementPlan m_QualityManagementPlan;
		public ProcessImprovementPlan m_ProcessImprovementPlan;
		public QualityMetrics m_QualityMetrics;
		public QualityChecklists m_QualityChecklists;
		public CommunicationsManagementPlan m_CommunicationsManagementPlan;
		public RiskManagementPlan m_RiskManagementPlan;
		public ProjectDocuments m_ProjectDocuments;
		public ProcurementManagementPlan m_ProcurementManagementPlan;
		public ProcurementStatementOfWork m_ProcurementStatementOfWork;
		public MakeOrBuyDecisions m_MakeOrBuyDecisions;
		public ChangeRequests m_ChangeRequests;
		public FinalProductServiceOrResultTransition m_FinalProductServiceOrResultTransition;
		public OrganizationalProcessAssetsUpdates m_OrganizationalProcessAssetsUpdates;
		public AcceptedDeliverables m_AcceptedDeliverables;
		public ClosedProcurements m_ClosedProcurements;
		public Deliverables m_Deliverables;
		public WorkPerformanceData m_WorkPerformanceData;
		public ApprovedChangeRequests m_ApprovedChangeRequests;
		public QualityControlMeasurements m_QualityControlMeasurements;
		public TeamPerformanceAssessments m_TeamPerformanceAssessments;
		public EnterpriseEnvironmentalFactorsUpdates m_EnterpriseEnvironmentalFactorsUpdates;
		public IssueLog m_IssueLog;
		public WorkPerformanceReports m_WorkPerformanceReports;
		public ProjectCommunications m_ProjectCommunications;
		public SelectedSellers m_SelectedSellers;
		public ResourceCalendar m_ResourceCalendar;
		public SellerProposals m_SellerProposals;
		public ChangeLog m_ChangeLog;
		public ScheduleForecasts m_ScheduleForecasts;
		public CostForecasts m_CostForecasts;
		public ValidatedChanges m_ValidatedChanges;
		public WorkPerformanceInformation m_WorkPerformanceInformation;
		public VerifiedDeliverables m_VerifiedDeliverables;
		public SourceSelectionCriteria m_SourceSelectionCriteria;

		public virtual void Initiating()
		{
			new ProjectManagementInitiating(this).Run();
		}

		public virtual void Planning()
		{
			new ProjectManagementPlanning(this).Run();
		}

		public virtual void Executing()
		{
			new ProjectManagementExecuting(this).Run();
		}

		public virtual void MonitoringAndControlling()
		{
			new ProjectManagementMonitoringAndControlling(this).Run();
		}

		public virtual void Closing()
		{
			new ProjectManagementClosing(this).Run();
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
}