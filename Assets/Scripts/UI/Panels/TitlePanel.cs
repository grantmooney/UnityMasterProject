using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitlePanel : BasePanel {
	[SerializeField] private Button m_playButton;

	public override void Awake() {
        base.Awake();
		m_playButton.onClick.AddListener (() => { OnPlayButtonClicked(); });
	}

	private void OnPlayButtonClicked() {
		LoadingPanel.LoadAdditive ("GameplayScene", ()=>{ PanelManager.Instance.SwitchPanel (this.gameObject, "GameplayPanel"); });
	}
}
