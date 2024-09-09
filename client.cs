using UnityEngine;
using UnityEngine.UI;
using System;

public class LuaExecutor : MonoBehaviour
{
    public InputField luaInputField;
    public Text outputText;
    public Button runButton;

    private LuaState lua;

    void Start()
    {
        lua = new LuaState(); 
        runButton.onClick.AddListener(ExecuteLuaCode);
    }

    void ExecuteLuaCode()
    {
        string luaCode = luaInputField.text;
        try
        {
            lua.DoString(luaCode); 
            var result = lua.GetGlobal("result");
            outputText.text = $"Output: {result}";
        }
        catch (Exception ex)
        {
            outputText.text = $"Error: {ex.Message}";
        }
    }
}
