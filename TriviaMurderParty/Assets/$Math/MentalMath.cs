using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class MentalMath : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    public KMSelectable WeedChungis;
    public TextMesh Fuck;
    public TextMesh[] Fuckers;
    public KMSelectable[] ModuleRicks;
    public TextMesh WeedFat;
    public GameObject Chungus;

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;
    float Weed = 0f;
    float Weedtwo = 0f;
    int ThresshyBoy = 0;
    float nowineedatimerfuck = 0f;
    int integer = 0;
    int integertwo = 0;
    int fucker = 0;
    private List<int> sugna = new List<int>{0,1,2,3};
    bool poggers = false;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Button in ModuleRicks) {
            Button.OnInteract += delegate () { ButtonPress(Button); return false; };
        }

        WeedChungis.OnInteract += delegate () { ChungusPress(); return false; };

    }

    void ChungusPress(){
      if (moduleSolved || poggers) {
        return;
      }
      Audio.PlaySoundAtTransform("Trivia Murder Party Math Weasel Timer", transform);
      PenisPress();
      StartCoroutine(FuckerFuckingFuck());
    }

    void ButtonPress(KMSelectable Button){
      for (int i = 0; i < 4; i++) {
        if (Button == ModuleRicks[i]) {
          if (i == sugna[0] && poggers) {
            Audio.PlaySoundAtTransform("BiggerDick", Button.transform);
            fucker += 1;
            StartCoroutine(WeedChungus());
          }
          else if (poggers == false) {
            return;
          }
          else {
            GetComponent<KMBombModule>().HandleStrike();
            Debug.LogFormat("[Mental Math #{0}] You pressed the wrong number, strike numbnuts.", moduleId);
          }
        }
      }
    }

    void PenisPress(){
      if (poggers) {
        return;
      }
      if (Weedtwo - Weed == 1) {
        ThresshyBoy = 1;
      }
      else if (Weed / Weedtwo >= .81f) {
        ThresshyBoy = 5;
      }
      else if (Weed / Weedtwo >= .61f) {
        ThresshyBoy = 10;
      }
      else if (Weed / Weedtwo >= .41f) {
        ThresshyBoy = 15;
      }
      else if (Weed / Weedtwo >= .21f) {
        ThresshyBoy = 20;
      }
      else if (Weed / Weedtwo >= .01f) {
        ThresshyBoy = 25;
      }
      else if (Weed / Weedtwo == 0f) {
        ThresshyBoy = 30;
      }
      else {
        ThresshyBoy = 1;
      }
      Debug.LogFormat("[Mental Math #{0}] {1} module(s) need to be solved.", moduleId, ThresshyBoy);
      StartCoroutine(WeedChungus());
    }

    IEnumerator WeedChungus(){
      poggers = true;
      integer = UnityEngine.Random.Range(0,16);
      integertwo = UnityEngine.Random.Range(0,16);
      if (UnityEngine.Random.Range(0,2) == 1) {
        Fuck.text = integer.ToString() + " - " + integertwo.ToString();
          Debug.LogFormat("[Mental Math #{0}] It shows {1} - {2}, the answer is {3}.", moduleId, integer, integertwo, integer - integertwo);
        integer -= integertwo;
      }
      else {
        Fuck.text = integer.ToString() + " + " + integertwo.ToString();
          Debug.LogFormat("[Mental Math #{0}] It shows {1} + {2}, the answer is {3}.", moduleId, integer, integertwo, integer + integertwo);
        integer += integertwo;
      }
      sugna.Shuffle();
      var x = UnityEngine.Random.Range(-5,6);
      while (x == 0) {
        x = UnityEngine.Random.Range(-5,6);
      }
      var y = UnityEngine.Random.Range(-5,6);
      while (y == 0 || y == x) {
        y = UnityEngine.Random.Range(-5,6);
      }
      var z = UnityEngine.Random.Range(-5,6);
      while (z == 0 || z == x || z == y) {
        z = UnityEngine.Random.Range(-5,6);
      }
      Fuckers[sugna[0]].text = integer.ToString();
      Fuckers[sugna[1]].text = (integer + x).ToString();
      Fuckers[sugna[2]].text = (integer + y).ToString();
      Fuckers[sugna[3]].text = (integer + z).ToString();
      yield return null;
    }

    void Update(){
      Weed = Bomb.GetSolvedModuleNames().Count;
      Weedtwo = Bomb.GetSolvableModuleNames().Count;
      if (poggers) {
        nowineedatimerfuck += Time.deltaTime;
        if (nowineedatimerfuck >= 30f) {
          Debug.Log("fukc");
          poggers = false;
          StopAllCoroutines();
          Chungus.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
          StartCoroutine(Check());
        }
      }
    }

    IEnumerator Check(){
      for (int i = 0; i < 4; i++) {
        Fuckers[i].text = "";
        Fuck.text = "";
      }
      WeedFat.text = fucker.ToString() + " out of " + ThresshyBoy.ToString();
      yield return new WaitForSeconds(5f);
      if (fucker >= ThresshyBoy) {
        GetComponent<KMBombModule>().HandlePass();
        moduleSolved = true;
        Debug.LogFormat("[Mental Math #{0}] You answered {1} out of the required {2}. Module disarmed.", moduleId, fucker, ThresshyBoy);
      }
      else {
        GetComponent<KMBombModule>().HandleStrike();
        Debug.LogFormat("[Mental Math #{0}] You answered {1} out of the required {2}. Strike.", moduleId, fucker, ThresshyBoy);
        nowineedatimerfuck = 0f;
        WeedFat.text = "";
        Fuck.text = "This is";
        Fuckers[0].text = "Your";
        Fuckers[1].text = "Wakeup Call";
        Fuckers[2].text = "Prepare";
        Fuckers[3].text = "To die!";
        fucker = 0;
      }
    }

    IEnumerator FuckerFuckingFuck(){
      Chungus.transform.Rotate(5.0f, 0.0f, 0.0f, Space.Self);
      yield return new WaitForSeconds(.00833333f);
      StartCoroutine(FuckerFuckingFuck());
    }

    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} crank to start. Use !{0} # to press the button from top to bottom.";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command){
      if (Regex.IsMatch(command, @"^\s*crank\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)){
        yield return null;
        WeedChungis.OnInteract();
        yield break;
      }
      else if (Regex.IsMatch(command, @"^\s*1\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) {
        yield return null;
        ModuleRicks[0].OnInteract();
        yield break;
      }
      else if (Regex.IsMatch(command, @"^\s*2\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) {
        yield return null;
        ModuleRicks[1].OnInteract();
        yield break;
      }
      else if (Regex.IsMatch(command, @"^\s*3\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) {
        yield return null;
        ModuleRicks[2].OnInteract();
        yield break;
      }
      else if (Regex.IsMatch(command, @"^\s*4\s*$", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant)) {
        yield return null;
        ModuleRicks[3].OnInteract();
        yield break;
      }
      else {
        yield return "sendtochaterror I don't understand!";
        yield break;
      }
    }
}
