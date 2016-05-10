// ProjectManagementClosing.cs
namespace PMBOK
{
	using System;

	using PMBOK.Processes;

	public class ProjectManagementClosing
	{
		public ProjectManagement ProjectManagement;
		private ProjectManagement pm
		{
			get
			{
				return this.ProjectManagement;
			}
		}

		public ProjectManagementClosing(ProjectManagement pm)
		{
			this.ProjectManagement = pm;
		}

		public virtual void Run()
		{
			Console.WriteLine("> > > Closing...");

			this.CloseProjectOrPhase(this.pm.m_ProjectManagementPlan, this.pm.m_AcceptedDeliverables, this.pm.m_OrganizationalProcessAssets);
			this.CloseProcurements(this.pm.m_ProjectManagementPlan, this.pm.m_ProcurementDocuments);
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

	}
}