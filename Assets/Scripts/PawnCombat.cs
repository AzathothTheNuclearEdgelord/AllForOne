using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnCombat : MonoBehaviour {
    private Camera camera;
    private Player player;
    private Pawn pawn;
    public LayerMask layerMask;
    public BattlePhase battlePhase;

    private void Start() {
        pawn = GetComponent<Pawn>();
        layerMask = battlePhase.pawnLayer;
        camera = GetComponentInChildren<Camera>();
    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Attack();
        }
    }

    void Attack() {
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, layerMask)) {
            if (hit.collider.gameObject.GetComponentInParent<Pawn>().player != pawn.player) {
                hit.collider.gameObject.GetComponentInParent<Pawn>().TakeDamage(pawn.combatUnit.strength);
            }
        }
    }
}