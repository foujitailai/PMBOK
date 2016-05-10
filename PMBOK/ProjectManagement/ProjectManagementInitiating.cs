namespace PMBOK
{
	using System;

	using PMBOK.Processes;

	public class ProjectManagementInitiating
	{
		public ProjectManagement ProjectManagement;
		private ProjectManagement pm
		{
			get
			{
				return this.ProjectManagement;
			}
		}

		public ProjectManagementInitiating(ProjectManagement pm)
		{
			this.ProjectManagement = pm;
		}

		public virtual void Run()
		{
			Console.WriteLine("> > > Initiating...");

			this.DevelopProjectCharter(this.pm.m_ProjectStatementOfWork, this.pm.m_BusinessCase, this.pm.m_Agreements, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
			this.IdentifyStakeholders(this.pm.m_ProjectCharter, this.pm.m_ProcurementDocuments, this.pm.m_EnterpriseEnvironmentalFactors, this.pm.m_OrganizationalProcessAssets);
		}

		ProjectCharter DevelopProjectCharter(
			ProjectStatementOfWork psow,
			BusinessCase bc,
			Agreements a,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new ProjectCharter();
		}

		StakeholderRegister IdentifyStakeholders(
			ProjectCharter pc,
			ProcurementDocuments pd,
			EnterpriseEnvironmentalFactors eef,
			OrganizationalProcessAssets opa)
		{
			return new StakeholderRegister();
		}
	}

}