using UnityEngine;
public class EnemyFactory : AbstractFactory
{
  public override void CreateAgent()
  {
    var agent = Instantiate(AgentPrefabs[Random.Range(0, AgentPrefabs.Count)], SpawnLocation.position, SpawnLocation.rotation);
    agent.GetComponent<EnemyAgent>().Navigate(AgentDestination.position);
  }
}