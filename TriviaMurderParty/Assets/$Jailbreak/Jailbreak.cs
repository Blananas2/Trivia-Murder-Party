using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class Jailbreak : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;
    private KMAudio.KMAudioRef WeedChungus;
    public KMSelectable[] Lomp;
    public TextMesh[] Aids;
    public TextMesh Emotiguy;
    public TextMesh NotEmotiguy;
    public TextMesh UselessShit;
    string MyDickisSoLongitStretchesFromAtoZ = "QWERTYUIOPASDFGHJKLZXCVBNM";
    string Yanked = "";
    string NuggetInABiscuit = "";
    int Fuck = 0;
    int Cock = 90;
    bool Check = false;
    bool IWillTimeYourDeath = false;
    bool shutup = false;
    bool No = false;
    #pragma warning disable 0649
    bool TwitchPlaysActive;
    #pragma warning restore 0649

    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Penis in Lomp) {
            Penis.OnInteract += delegate () { PenisPress(Penis); return false; };
        }
        GetComponent<KMBombModule>().OnActivate += delegate () {Activate(); };
    }

    // Use this for initialization
    void Activate () {
      for (int i = 0; i < 4; i++) {
        Aids[i].text = "_";
      }
      NotEmotiguy.text = "Query";
      StartCoroutine(IWillPurgeTheWeak());
    }

    void PenisPress(KMSelectable Penis) {
      Audio.PlaySoundAtTransform("Clack", Penis.transform);
      Penis.AddInteractionPunch();
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, Penis.transform);
      if (No) {
        return;
      }
      for (int i = 0; i < 27; i++) {
        if (moduleSolved) {
          return;
        }
        if (IWillTimeYourDeath == false) {
          StartCoroutine(SoonThatAttitudeWillBeYourDoom());
          StartCoroutine(hgjymgjuyhkhgjymijuyhkhftjuyhjuymgfhjvmghgjmfhgjmfnhgjymfnhgjhgfnhgfjygfhhtjuyhmgfjyhjuymghgjymfhmgnbjmgnbjhnbhvmnFUCKWEEDhgfjyhcgnbhjymgfhmgnjhjymghmjgnhmgnj());
        }
        if (Penis == Lomp[i] && i != 26) {
          if (NuggetInABiscuit.Length == 4) {
            return;
          }
          NuggetInABiscuit += MyDickisSoLongitStretchesFromAtoZ[i].ToString();
          NotEmotiguy.text = NuggetInABiscuit;
        }
        else if (NuggetInABiscuit.ToLower() == Yanked && Penis == Lomp[i]) {
          StopAllCoroutines();
          StartCoroutine(SolveThing());
        }
        else if (Penis == Lomp[i] && NuggetInABiscuit.Length < 4) {
          GetComponent<KMBombModule>().HandleStrike();
          Audio.PlaySoundAtTransform("DooDooDooDoo", transform);
          NotEmotiguy.text = "Query";
          NuggetInABiscuit = "";
          NotEmotiguy.text = NuggetInABiscuit;
        }
        else if (Penis == Lomp[i] && i == 26 && NuggetInABiscuit.Length == 4) {
          for (int j = 0; j < AidsList.Phrases.Count(); j++) {
            if (NuggetInABiscuit.ToLower() == AidsList.Phrases[j]) {
              Check = true;
              break;
            }
          }
            for (int j = 0; j < 4; j++) {
              if (NuggetInABiscuit[j].ToString().ToLower() == Yanked[j].ToString() && Check) {
                Aids[j].text = NuggetInABiscuit[j].ToString();
              }
            }
            if (Check == false) {
              Debug.LogFormat("[Jailbreak #{0}] You queried {1}, but that is not a word!", moduleId, NuggetInABiscuit);
            }
            else {
              Debug.LogFormat("[Jailbreak #{0}] You queried {1}. It shows {2} {3} {4} {5}.", moduleId, NuggetInABiscuit, Aids[0].text, Aids[1].text, Aids[2].text, Aids[3].text);
            }
            NuggetInABiscuit = "";
            NotEmotiguy.text = "Query";
        }
        Check = false;
      }
    }

    IEnumerator IWillPurgeTheWeak(){
      Fuck = UnityEngine.Random.Range(0,AidsList.Phrases.Count());
      Yanked = AidsList.Phrases[Fuck];
      while (TwitchPlaysActive && Yanked.ToUpper() == "HELP") {
        Fuck = UnityEngine.Random.Range(0,AidsList.Phrases.Count());
        Yanked = AidsList.Phrases[Fuck];
      }
      Debug.LogFormat("[Jailbreak #{0}] The generated word is {1}.", moduleId, Yanked);
      yield return null;
    }

    IEnumerator SoonThatAttitudeWillBeYourDoom(){
      IWillTimeYourDeath = true;
      yield return new WaitForSecondsRealtime(1f);
      Cock -= 1;
      Emotiguy.text = Cock.ToString();
      if (Cock == 30) {
        shutup = true;
        WeedChungus = Audio.PlaySoundAtTransformWithRef("clock", transform);
      }
      if (Cock == 0) {
        if (WeedChungus != null) {
          WeedChungus.StopSound();
          WeedChungus = null;
        }
        for (int i = 0; i < 4; i++) {
          Aids[i].text = Yanked[i].ToString().ToUpper();
        }
        Debug.LogFormat("[Jailbreak #{0}] You took to long!", moduleId);
        shutup = false;
        No = true;
        yield return new WaitForSecondsRealtime(5f);
        No = false;
        GetComponent<KMBombModule>().HandleStrike();
        Audio.PlaySoundAtTransform("DooDooDooDoo", transform);
        StartCoroutine(IWillPurgeTheWeak());
        IWillTimeYourDeath = false;
        Cock = 90;
        for (int i = 0; i < 4; i++) {
          Aids[i].text = "_";
        }
      }
      else {
        StartCoroutine(SoonThatAttitudeWillBeYourDoom());
      }
    }

    IEnumerator hgjymgjuyhkhgjymijuyhkhftjuyhjuymgfhjvmghgjmfhgjmfnhgjymfnhgjhgfnhgfjygfhhtjuyhmgfjyhjuymghgjymfhmgnbjmgnbjhnbhvmnFUCKWEEDhgfjyhcgnbhjymgfhmgnjhjymghmjgnhmgnj(){
      yield return new WaitForSeconds(0.2f);
      Audio.PlaySoundAtTransform("tick", transform);
      if (shutup) {
        yield return null;
      }
      else {
        StartCoroutine(hgjymgjuyhkhgjymijuyhkhftjuyhjuymgfhjvmghgjmfhgjmfnhgjymfnhgjhgfnhgfjygfhhtjuyhmgfjyhjuymghgjymfhmgnbjmgnbjhnbhvmnFUCKWEEDhgfjyhcgnbhjymgfhmgnjhjymghmjgnhmgnj());
      }
    }

    IEnumerator SolveThing(){
      if (WeedChungus != null) {
        WeedChungus.StopSound();
        WeedChungus = null;
      }
      for (int j = 0; j < 4; j++) {
        Aids[j].text = Yanked[j].ToString().ToUpper();
      }
      yield return new WaitForSeconds(3f);
      if (Aids[0].text.ToString() != "J") {
        Aids[0].text = "J";
        yield return new WaitForSeconds(1f);
      }
      if (Aids[1].text.ToString() != "A") {
        Aids[1].text = "A";
        yield return new WaitForSeconds(1f);
      }
      if (Aids[2].text.ToString() != "I") {
        Aids[2].text = "I";
        yield return new WaitForSeconds(1f);
      }
      if (Aids[3].text.ToString() != "L") {
        Aids[3].text = "L";
        yield return new WaitForSeconds(1f);
      }
      NotEmotiguy.text = "B";
      yield return new WaitForSeconds(.2f);
      NotEmotiguy.text = "BR";
      yield return new WaitForSeconds(.2f);
      NotEmotiguy.text = "BRO";
      yield return new WaitForSeconds(.2f);
      NotEmotiguy.text = "BROK";
      yield return new WaitForSeconds(.2f);
      NotEmotiguy.text = "BROKE";
      yield return new WaitForSeconds(.2f);
      Emotiguy.text = "";
      UselessShit.text = "?!";
      Debug.LogFormat("[Jailbreak #{0}] You guessed the word. Module disarmed.", moduleId);
      GetComponent<KMBombModule>().HandlePass();
      Audio.PlaySoundAtTransform("DooDOodoodoodooDOoooooo", transform);
      moduleSolved = true;
    }

    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"Use !{0} XXXX to guess a word.";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command){
      bool[] Dumbass = {false,false,false,false};
      yield return null;
      if (command.Length > 4) {
        yield return "sendtochaterror Too big a word!";
      }
      else if (command.Length < 4) {
        GetComponent<KMBombModule>().HandleStrike();
        Audio.PlaySoundAtTransform("DooDooDooDoo", transform);
        yield break;
      }
      else {
        for (int i = 0; i < command.Length; i++) {
          for (int j = 0; j < 26; j++) {
            if (command[i].ToString().ToUpper() == MyDickisSoLongitStretchesFromAtoZ[j].ToString().ToUpper()) {
              Dumbass[i] = true;
            }
          }
        }
        if (Dumbass[0] && Dumbass[1] && Dumbass[2] && Dumbass[3]) {
          for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 26; j++) {
              if (command[i].ToString().ToUpper() == MyDickisSoLongitStretchesFromAtoZ[j].ToString().ToUpper()) {
                Lomp[j].OnInteract();
                Dumbass[i] = false;
                yield return new WaitForSeconds(.01f);
              }
            }
          }
          Lomp[26].OnInteract();
          if (command.ToUpper() == Yanked.ToUpper()) {
            yield return "solve";
          }
          }
          else {
            yield return "sendtochaterror Invalid Character!";
            yield break;
          }
      }
    }
}
