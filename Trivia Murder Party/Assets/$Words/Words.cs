using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using UnityEngine;
using Rnd = UnityEngine.Random;

public class Words : MonoBehaviour {

   public KMBombInfo Bomb;
   public KMAudio Audio;

   public KMSelectable[] Buttons;
   public TextMesh[] Letters;

   int TotalPoints;

   string CurrentSubmission = "";
   string ChosenWord = "";

   bool[] HaveBeenPressed = new bool[24];
   bool IsAWord;
   bool Animating;

   char[] ShownLetters = new char[24];

   //Logging
   static int moduleIdCounter = 1;
   int moduleId;
   private bool moduleSolved;

   void Awake () {
      moduleId = moduleIdCounter++;
      foreach (KMSelectable Button in Buttons) {
         Button.OnInteract += delegate () { ButtonPress(Button); return false; };
      }
   }

   void Start () {
      StartCoroutine(WordGeneration());
   }

   void ButtonPress (KMSelectable Button) {
      Button.AddInteractionPunch();
      Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, transform);
      if (Animating) {
         return;
      }
      for (int i = 0; i < 24; i++) {
         if (Button == Buttons[i]) {
            if (!HaveBeenPressed[i]) {
               HaveBeenPressed[i] = true;
               CurrentSubmission += ShownLetters[i].ToString();
            }
            else {
               for (int q = 0; q < 3; q++) {
                  for (int j = 0; j < MinorWordList.AllWords[q].Length; j++) { //With the original way I had this, the giant word list was an array, so I wanted to search the smaller list first.
                     if (CurrentSubmission == MinorWordList.AllWords[q][j]) {
                        IsAWord = true;
                        break;
                     }
                  }
               }
               if (AllWordList.List.Contains(CurrentSubmission)) { //I then looked at boggle's code, since it is fast, and it is a simple .Contains()
                  IsAWord = true;
               }
               if (IsAWord) {
                  TotalPoints += PointCalculator(CurrentSubmission);
                  Debug.LogFormat("[Words #{0}] You submitted {1}, which is a word. You now have {2} points.", moduleId, CurrentSubmission, TotalPoints);
               }
               else {
                  TotalPoints--;
                  Debug.LogFormat("[Words #{0}] You submitted {1}, which is not a word. You now have {2} points.", moduleId, CurrentSubmission, TotalPoints);
               }
               for (int p = 0; p < 24; p++) {
                  HaveBeenPressed[p] = false;
               }
               if (TotalPoints >= 30) {
                  GetComponent<KMBombModule>().HandlePass();
                  moduleSolved = true;
               }
               IsAWord = false;
               CurrentSubmission = "";
               StartCoroutine(PointsDisplay());
            }
         }
      }
   }

   IEnumerator PointsDisplay () {
      Animating = true;
      for (int i = 0; i < 24; i++) {
         Letters[i].text = "";
         yield return new WaitForSecondsRealtime(.1f);
      }
      for (int i = 4; i < 9; i++) {
         Letters[i].text = "TOTAL"[i - 4].ToString();
         yield return new WaitForSecondsRealtime(.1f);
      }
      for (int i = 9; i < 14; i++) {
         Letters[i].text = "POINT"[i - 9].ToString();
         yield return new WaitForSecondsRealtime(.1f);
      }
      for (int i = 14; i < 19; i++) {
         Letters[i].text = "EQUAL"[i - 14].ToString();
         yield return new WaitForSecondsRealtime(.1f);
      }
      if (TotalPoints >= 0) {
         Letters[20].text = "+";
      }
      else {
         Letters[20].text = "-";
      }
      yield return new WaitForSecondsRealtime(.1f);
      Letters[21].text = (Math.Abs(TotalPoints / 10) % 10).ToString();
      yield return new WaitForSecondsRealtime(.1f);
      Letters[22].text = Math.Abs(TotalPoints % 10).ToString();
      yield return new WaitForSecondsRealtime(1f);
      StartCoroutine(WordGeneration());
   }

   int PointCalculator (string Input) {
      switch (Input.Length) {
         case 1:
            return 0;
         case 2:
            return 1;
         case 3:
            return 2;
         case 4:
            return 4;
         case 5:
            return 7;
         case 6:
            return 10;
         case 7:
            return 15;
         case 8:
            return 25;
         default:
            return 30;
      }
   }

   IEnumerator WordGeneration () {
      Animating = true;
      int Temp = Rnd.Range(0, 3);
      ChosenWord = MinorWordList.AllWords[Temp][Rnd.Range(0, MinorWordList.AllWords[Temp].Length)];
      Debug.LogFormat("[Words #{0}] The chosen word is {1}.", moduleId, ChosenWord);
      Debug.LogFormat("[Words #{0}] The grid shown is:", moduleId);
      for (int i = 0; i < ChosenWord.Length; i++) {
         ShownLetters[i] = ChosenWord[i];
      }
      for (int i = ChosenWord.Length; i < 24; i++) {
         ShownLetters[i] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"[Rnd.Range(0, 26)];
      }
      ShownLetters.Shuffle();
      for (int i = 0; i < 24; i++) {
         Letters[i].text = ShownLetters[i].ToString();
         yield return new WaitForSecondsRealtime(.1f);
      }
      Animating = false;
      Debug.LogFormat("[Words #{0}] {1}{2}{3}{4}.", moduleId, ShownLetters[0], ShownLetters[1], ShownLetters[2], ShownLetters[3]);
      Debug.LogFormat("[Words #{0}] {1}{2}{3}{4}{5}", moduleId, ShownLetters[4], ShownLetters[5], ShownLetters[6], ShownLetters[7], ShownLetters[8]);
      Debug.LogFormat("[Words #{0}] {1}{2}{3}{4}{5}", moduleId, ShownLetters[9], ShownLetters[10], ShownLetters[11], ShownLetters[12], ShownLetters[13]);
      Debug.LogFormat("[Words #{0}] {1}{2}{3}{4}{5}", moduleId, ShownLetters[14], ShownLetters[15], ShownLetters[16], ShownLetters[17], ShownLetters[18]);
      Debug.LogFormat("[Words #{0}] {1}{2}{3}{4}{5}", moduleId, ShownLetters[19], ShownLetters[20], ShownLetters[21], ShownLetters[22], ShownLetters[23]);
   }

#pragma warning disable 414
   private readonly string TwitchHelpMessage = @"Use !{0} submit APPLE to submit that word into the module.";
#pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        List<string> parameters = command.Trim().ToUpper().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        if (parameters.Count != 2 || parameters[0] != "SUBMIT" || parameters[1].Any(x => !"ABCDEFGHIJKLMNOPQRSTUVWXYZ".Contains(x)))
            yield break;
        string submitting = parameters[1];
        List<char> availableLetters = ShownLetters.ToList();
        List<int> submitSequence = new List<int>();
        while (Animating) yield return "trycancel";
        foreach (char letter in submitting)
        {
            if (!availableLetters.Contains(letter))
            {
                yield return "sendtochaterror The submitted word is unable to be made.";
                yield break;
            }
            int index = Enumerable.Range(0, 25).First(ix => availableLetters[ix] == letter);
            availableLetters[index] = '-';
            submitSequence.Add(index);
        }
        submitSequence.Add(submitSequence.PickRandom());
        yield return null;
        foreach (int index in submitSequence)
        {
            Buttons[index].OnInteract();
            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator TwitchHandleForcedSolve () {
      if (CurrentSubmission != "") {
         for (int i = 0; i < 24; i++) {
            if (HaveBeenPressed[i]) {
               Buttons[i].OnInteract();
            }
         }
      }
      while (Animating) {
         yield return true;
      }
      while (!moduleSolved) {
         bool HasPressed = false;
         for (int i = 0; i < ChosenWord.Length; i++) {
            for (int j = 0; j < 24; j++) {
               if (Letters[j].text == ChosenWord[i].ToString() && !HaveBeenPressed[j] && !HasPressed) {
                  Buttons[j].OnInteract();
                  yield return new WaitForSecondsRealtime(.1f);
                  HasPressed = true;
               }
            }
            HasPressed = false;
         }
         for (int i = 0; i < 24; i++) {
            if (HaveBeenPressed[i]) {
               Buttons[i].OnInteract();
               yield return new WaitForSecondsRealtime(.1f);
               break;
            }
         }
         while (Animating) {
            yield return true;
         }
      }
   }
}
