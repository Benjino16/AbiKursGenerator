using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    List<DropDownList> dropDowns;
    protected void Page_Load(object sender, EventArgs e)
    {
        dropDowns = new List<DropDownList>() { DDP_LK1, DDP_LK2, DDP_SGK1, DDP_SGK2, DDP_MGK1, DDP_MGK2, DDP_AK1, DDP_AK2 };

        if (KursGenerator.pageLoadCounter == 0)
        {
            //This Code runs one timer on setup of the website:


        }
        KursGenerator.pageLoadCounter++;
    }

    protected void CheckButtonClicked(object sender, EventArgs e)
    {
        CheckListPanel.Visible = true;
        SetKursauswahl();
        KursGenerator.CheckKurseAuswahl();
        RuleText1.Text = KursGenerator.PrintResult(0);
        RuleText2.Text = KursGenerator.PrintResult(1);
        RuleText3.Text = KursGenerator.PrintResult(2);
        RuleText4.Text = KursGenerator.PrintResult(3);
        RuleText5.Text = KursGenerator.PrintResult(4);

        if (KursGenerator.AllRulesTrue())
        {
            ResultText.ForeColor = System.Drawing.Color.Green;
            //SaveKursButton.Visible = true;
        }
        else
        {
            ResultText.ForeColor = System.Drawing.Color.Red;
        }
        ResultText.Text = KursGenerator.PrintResult(5);
    }

    void SetKursauswahl()
    {
        KursGenerator.selectedLK1 = FindKursByString(DDP_LK1.Text);
        KursGenerator.selectedLK2 = FindKursByString(DDP_LK2.Text);
        KursGenerator.selectedSGK1 = FindKursByString(DDP_SGK1.Text);
        KursGenerator.selectedSGK2 = FindKursByString(DDP_SGK2.Text);
        KursGenerator.selectedMGK1 = FindKursByString(DDP_MGK1.Text);
        KursGenerator.selectedMGK2 = FindKursByString(DDP_MGK2.Text);
        KursGenerator.selectedAK1 = FindKursByString(DDP_AK1.Text);
        KursGenerator.selectedAK2 = FindKursByString(DDP_AK2.Text);

        KursGenerator.UpdateList();
    }

    Kurs FindKursByString(string name)
    {
        return KursGenerator.allKurse.Find(r => r.name == name);
    }


    protected void SaveButtonClicked(object sender, EventArgs e)
    {
        SaveKursPanel.Visible = true;
    }

    protected void CalculatePointsFunction(object sender, EventArgs e)
    {
        if(NotenTextBox1.Visible)
        {
            //Calculate Note
            NotenText.Text = NotenGenerator.CalculateSchriftlichePunkte(NotenTextBox1.Text, NotenTextBox2.Text, NotenTextBox3.Text, NotenTextBox4.Text, NotenTextBox5.Text, NotenTextBox6.Text, NotenTextBox7.Text, NotenTextBox8.Text);
            NotenPanel.Visible = true;
        }
        else
        {
            ShowNoteButtons(true);
        }
        
    }


    void ShowNoteButtons(bool show)
    {
        NotenTextBox1.Visible = show;
        NotenTextBox2.Visible = show;
        NotenTextBox3.Visible = show;
        NotenTextBox4.Visible = show;
        NotenTextBox5.Visible = show;
        NotenTextBox6.Visible = show;
        NotenTextBox7.Visible = show;
        NotenTextBox8.Visible = show;
    }
}


#region KursGenerator
public static class KursGenerator
{
    public static int pageLoadCounter = 0;


    #region Defined Kurse



    static Kurs deutsch = new Kurs("Deutsch", Aufgabenfeld.Eins);
    static Kurs mathematik = new Kurs("Mathematik", Aufgabenfeld.Drei);
    static Kurs englisch = new Kurs("Englisch", Aufgabenfeld.Eins);
    static Kurs bildeneKunst = new Kurs("Bildende Kunst", Aufgabenfeld.Eins);
    static Kurs biologie = new Kurs("Biologie", Aufgabenfeld.Drei);
    static Kurs chemie = new Kurs("Chemie", Aufgabenfeld.Drei);
    static Kurs politikWissenschaft = new Kurs("Politikwissenschaft", Aufgabenfeld.Zwei);
    static Kurs geographie = new Kurs("Geographie", Aufgabenfeld.Zwei);
    static Kurs russisch = new Kurs("Russisch", Aufgabenfeld.Eins);
    static Kurs darstellendesSpiel = new Kurs("Darstellendes Spiel", Aufgabenfeld.Eins);

    public static List<Kurs> allKurse = new List<Kurs>
    {
        deutsch, mathematik, englisch, bildeneKunst, biologie, chemie, politikWissenschaft, geographie, russisch, darstellendesSpiel
    };

    public static List<Kurs> aufgabenfeld1 = new List<Kurs> { deutsch, englisch, russisch, bildeneKunst, darstellendesSpiel };
    public static List<Kurs> aufgabenfeld2 = new List<Kurs> { geographie, politikWissenschaft };
    public static List<Kurs> aufgabenfeld3 = new List<Kurs> { mathematik, biologie, chemie };

    #endregion

    #region Selected Kurse
    public static Kurs selectedLK1 = null;
    public static Kurs selectedLK2 = null;
    public static Kurs selectedMGK1 = null;
    public static Kurs selectedMGK2 = null;
    public static Kurs selectedSGK1 = null;
    public static Kurs selectedSGK2 = null;
    public static Kurs selectedAK1 = null;
    public static Kurs selectedAK2 = null;


    public static List<Kurs> prüfungsfächer = new List<Kurs> { selectedLK1, selectedLK2, selectedSGK1, selectedSGK2, selectedMGK1, selectedMGK2, selectedAK1, selectedAK2};

    public static List<Kurs> schriftlKurse = new List<Kurs> { selectedLK1, selectedLK2, selectedSGK1, selectedSGK2 };

    #endregion


    static bool everyFieldIsChoosen;
    static bool nodoubledKurse;
    static bool rule1;
    static bool rule2;
    static bool rule3;


    public static void UpdateList()
    {
        prüfungsfächer = new List<Kurs> { selectedLK1, selectedLK2, selectedSGK1, selectedSGK2, selectedMGK1, selectedMGK2, selectedAK1, selectedAK2 };
        schriftlKurse = new List<Kurs> { selectedLK1, selectedLK2, selectedSGK1, selectedSGK2 };
    }



    public static void CheckKurseAuswahl()
    {

        // Alle felder wurden belegt.

        everyFieldIsChoosen = true;
        foreach (Kurs kurs1 in prüfungsfächer)
        {
            if (kurs1 == null)
            {
                everyFieldIsChoosen = false;
            }
        }


        //Kein Feld wurde doppelt belegt

        nodoubledKurse = true;
        foreach (Kurs kurs in prüfungsfächer)
        {
            int counter = 0;
            foreach (Kurs kurs2 in prüfungsfächer)
            {
                if(kurs == kurs2)
                {
                    counter++;
                }
                if(counter > 1)
                {
                    nodoubledKurse = false;
                }
            }
        }



        //1. Unter den Prüfungsfächern müssen sich die Fächer Deutsch, Geographie oder ein anderes gesellschaftwissenschaftliches Fach, Mathematik, eine Naturwissenschaft und zwei Fremdsprachen befinden.


        if (prüfungsfächer.Contains(deutsch) &&
            (prüfungsfächer.Contains(geographie) || prüfungsfächer.Contains(politikWissenschaft)) &&
            prüfungsfächer.Contains(mathematik) && (prüfungsfächer.Contains(biologie) || prüfungsfächer.Contains(chemie)) &&
            prüfungsfächer.Contains(russisch) && prüfungsfächer.Contains(englisch))
        {

            rule1 = true;
        }
        else
        {
            rule1 = false;
        }


        //2. Aus jedem der genannten Aufgabenfelder ist mindesteens ein schriftliches Prüfungsfach zu wählen.

        if(schriftlKurse.Any(f => f!=null && f.aufgabenfeld == Aufgabenfeld.Eins) && schriftlKurse.Any(g => g!=null && g.aufgabenfeld == Aufgabenfeld.Zwei && schriftlKurse.Any(b => b!=null && b.aufgabenfeld == Aufgabenfeld.Drei)))
        {
            rule2 = true;
        }
        else
        {
            rule2 = false;
        }




        //3. Unter den Fächern der schriftlichen Prüfung müssen sich das Fach Mathematik und eines der Fächer Deutsch oder eine Fremdsprache befinden.
      
        if(schriftlKurse.Contains(mathematik) && (schriftlKurse.Contains(deutsch) || schriftlKurse.Contains(englisch)  || schriftlKurse.Contains(russisch)))
        {
            rule3 = true;
        }
        else
        {
            rule3 = false;
        }
    }

    public static bool AllRulesTrue()
    {
        return (everyFieldIsChoosen && nodoubledKurse && rule1 && rule2 && rule2);
    }

    public static string PrintResult(int i)
    {
        string[] results = new string[6];

        results[0] = "Jeder Kurs wurde belegt: " + BoolToEmoji(everyFieldIsChoosen);
        results[1] = "Kein Kurs wurde doppelt gewählt: " + BoolToEmoji(nodoubledKurse);
        results[2] = "Bedingung 1: " + BoolToEmoji(rule1);
        results[3] = "Bedingung 2: " + BoolToEmoji(rule2);
        results[4] = "Bedingung 3: " + BoolToEmoji(rule3);

        if (AllRulesTrue())
        {
            results[5] = "Du hast eine Auswahl getroffen, die alle Bedingungen erfüllt. Super!";
        }
        else
        {
            results[5] = "Deine gewählten Kurse erfüllen leider nicht alle Bedinungen :( Überprüfe diese und passe deine Auswahl an!";
        }
        

        return results[i];
    }


    static string BoolToEmoji(bool theBool)
    {
        if(theBool)
        {
            return "✔";
        }
        return "✖";
    }

}


public static class NotenGenerator
{
    /*
    static int LK1;
    static int LK2;
    static int SGK1;
    static int SGK2;
    static int MGK1;
    static int MGK2;
    static int AN1;
    static int AN2;

    */
    static int LKMultiplier = 13;
    static int GKMultiplier = 9;
    static int MGKMultiplier = 4;


    static List<string> notesAsString = new List<string>() { "6", "5-", "5", "5+", "4-", "4", "4+", "3-", "3", "3+", "2-", "2", "2+", "1-", "1", "1+" };


    static int NoteToInt(string note)
    {
        if(notesAsString.Any(r => r == note))
        {
            return notesAsString.FindIndex(r => r == note);
        }
        return 6;
    }


    static string PointsToNote(int points)
    {
        return notesAsString[(points / 60)];
    }


    public static string CalculateSchriftlichePunkte(string LK1, string LK2, string SGK1, string SGK2, string MGK1, string MGK2, string AN1, string AN2)
    {
        int schriftPunkte = (NoteToInt(LK1) * LKMultiplier) + (NoteToInt(LK2) * LKMultiplier) + (NoteToInt(SGK1) * GKMultiplier) + (NoteToInt(SGK2) * GKMultiplier);

        int mündPunkte = (NoteToInt(MGK1) * MGKMultiplier) + (NoteToInt(MGK2) * MGKMultiplier) + (NoteToInt(AN1) * MGKMultiplier) + (NoteToInt(AN2) * MGKMultiplier);

        int gesamtPunkte = mündPunkte + schriftPunkte;

        if (schriftPunkte > 220 && mündPunkte > 80)
        {
            return "Du hättest das Abitur mit folgender Durchschnitsnote bestanden: " + PointsToNote(gesamtPunkte);
        }
        else
        {
            return "Du hättest dein Abitur mit folgender Note nicht bestanden: " + PointsToNote(gesamtPunkte);
        }
    }

}


public class Kurs
{
    public string name;
    public Aufgabenfeld aufgabenfeld;

    public Kurs(string NAME, Aufgabenfeld AUFGABENFELD)
    {
        name = NAME;
        aufgabenfeld = AUFGABENFELD;
    }
}

public enum Aufgabenfeld
{
    Eins,
    Zwei,
    Drei
}

#endregion
//THE END :)