// ProjectManagementClosing.cs
namespace PMBOK
{
	using System;
	using System.Diagnostics;

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
			Debugger.Assert(pmp != null);
			Debugger.Assert(ad != null);
			Debugger.Assert(op != null);
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
			Debugger.Assert(pmp != null);
			Debugger.Assert(pd != null);
			return new CloseProcurementsResult();
		}

	}
}