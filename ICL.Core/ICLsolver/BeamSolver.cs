﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhino;
using Rhino.Geometry;

using ICD.AbmFramework.Core.AgentSystem;
using ICD.AbmFramework.Core;
using ICD.AbmFramework.Core.Agent;

using ICL.Core.AgentBehaviors;
//using ICD.AbmFramework.Core.Solver;

using ICL.Core.AgentSystem;


namespace ICL.Core.ICLsolver
{
    public class BeamSolver : Solver
    {

        /// <summary>  solver with display conduit</summary>
        public void ICLbeamSolverExecute()
        {
            //IterationCount++;

            foreach (AgentSystemBase agentSystem in this.AgentSystems)
                if (!agentSystem.IsFinished()) agentSystem.PreExecute();

            foreach (AgentSystemBase agentSystem in AgentSystems)
            {
                if (!agentSystem.IsFinished())
                {
                    agentSystem.Execute();
                    foreach (CartesianAgent agent in agentSystem.Agents)
                    {
                        RhinoApp.WriteLine(agent.Moves.Count + "moves");
                    }
                }

            }

            foreach (AgentSystemBase agentSystem in AgentSystems)
            {
                if (!agentSystem.IsFinished())
                {
                    agentSystem.PostExecute();
                    foreach (CartesianAgent agent in agentSystem.Agents)
                    {
                        Point3d pt = agent.Position;
                        RhinoApp.WriteLine(pt + "position update");
                    }
                }
            }

            //foreach (ICLcartesianAgentSystem agentSystem in AgentSystems)
            //{
            //    if (!agentSystem.IsFinished())
            //    {
            //        List<Point3d> updatedAgentPositions = UpdatedPositions(agentSystem);
            //        agentSystem.CartesianEnvironment.AgentStartPositons = updatedAgentPositions;
            //        agentSystem.CartesianEnvironment.UpdateEnvironment();
            //    }
            //}
        }

        public List<Point3d> UpdatedPositions(ICLcartesianAgentSystem agentSystem)
        {
            List<Point3d> agentPositionsUpdate = new List<Point3d>();

            foreach (CartesianAgent agent in agentSystem.Agents)
            {
                Point3d point = agent.Position;
                agentPositionsUpdate.Add(point);
            }
            return agentPositionsUpdate;
        }

    }
}

