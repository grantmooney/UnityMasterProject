using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CanvasRenderer))]
public class BasePanel : MonoBehaviour {
    [System.Serializable]
    public struct PanelButton {
        public Button button;
        public BasePanel targetPanel;
    }

    public PanelButton[] m_panelButtons;

    public virtual void Awake() {
        foreach (PanelButton panelButton in m_panelButtons) {
            panelButton.button.onClick.AddListener(() => { OnPanelButtonClicked(panelButton.targetPanel.gameObject); });
        }
    }

    private void OnPanelButtonClicked(GameObject targetGameObject) {
        PanelManager.Instance.SwitchPanel(this.gameObject, targetGameObject);
	}
}
