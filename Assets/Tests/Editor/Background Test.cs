using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.SceneManagement;

public class BackgroundTest {

	[Test]
	public void EditorTest() {
		//Arrange
		var gameObject = new GameObject();

		//Act
		//Try to rename the GameObject
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;

		//Assert
		//The object has a new name
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

	[Test]
	public void LoadingSceneTest() {
		//ChecksFor correct Number of scenes being loaded
		int counter = SceneManager.sceneCount;
		SceneManager.LoadScene("InjectionGame");
		Assert.AreEqual (counter + 1, SceneManager.sceneCount);
	}
}
