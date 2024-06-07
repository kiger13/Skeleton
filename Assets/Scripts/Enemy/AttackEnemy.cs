using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.TryGetComponent(out HealthPlayer player))
        {
            player.TryApplyDamage();
        }
    }
}
