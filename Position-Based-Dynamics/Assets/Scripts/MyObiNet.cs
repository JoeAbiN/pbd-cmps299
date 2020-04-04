using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

[RequireComponent(typeof(ObiActor))]
public class MyObiNet : MonoBehaviour {
    ObiActor actor;
    ObiSolver solver;
    ObiActorBlueprint blueprint;
    ObiParticleGroup fixedGroup;

    void Start() {
        actor = GetComponent<ObiActor>();
        solver = actor.solver;
        blueprint = actor.blueprint;
        fixedGroup = blueprint.groups[0];
        Debug.Log(fixedGroup);

        for (int i = 0; i < actor.solverIndices.Length; ++i){
			int solverIndex = actor.solverIndices[i];
			float invMass = actor.solver.invMasses[solverIndex];
            
            if (fixedGroup.ContainsParticle(solverIndex)) {
                Debug.Log("fixed");
                actor.solver.invMasses[solverIndex] = 0;
            }
            
            // Debug.Log(invMass);
		}
    }
}
