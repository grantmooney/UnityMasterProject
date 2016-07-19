using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayPanel : BasePanel {
	[SerializeField] private Button m_exitButton;

    public override void Awake() {
        base.Awake();
		m_exitButton.onClick.AddListener(() => { OnExitButtonClicked (); });
	}

	private void OnExitButtonClicked() {
		PanelManager.Instance.SwitchPanel(this.gameObject, "TitlePanel");
		LoadManager.Instance.LoadAsync("EmptyScene");
		System.GC.Collect ();
	}
}
