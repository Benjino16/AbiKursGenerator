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
        UpdateAllDropdowns();
        KursGenerator.ActivateAllKurse();
        if (KursGenerator.pageLoadCounter == 0)
        {
            KursGenerator.ActivateAllKurse();
        }
        KursGenerator.pageLoadCounter++;
    }

    private void UpdateDropdown(DropDownList dropDown, List<Kurs> kursListe)
    {
        string text = dropDown.SelectedItem.Text;

        dropDown.Items.Clear();
        dropDown.Items.Add(new ListItem { Text = "- None -" });
        foreach (Kurs kurs in kursListe)
        {
            if(!kurs.choosen)
            {
                dropDown.Items.Add(new ListItem { Text = kurs.name, Selected = (kurs.name == text) });
            }
        }
    }

    private void UpdateAllDropdowns()
    {
        UpdateDropdown(DDP_LK1, KursGenerator.LK1);
        UpdateDropdown(DDP_LK2, KursGenerator.LK2);
        UpdateDropdown(DDP_MGK1, KursGenerator.mGK1);
        UpdateDropdown(DDP_MGK2, KursGenerator.mGK2);
        UpdateDropdown(DDP_SGK1, KursGenerator.sGK1);
        UpdateDropdown(DDP_SGK2, KursGenerator.sGK2);
        UpdateDropdown(DDP_AK1, KursGenerator.AK1);
        UpdateDropdown(DDP_AK2, KursGenerator.AK2);
    }

    private void DropdownEnableItem(bool enabled, DropDownList dropDown, string item)
    {
        if(enabled)
        {
            dropDown.Items.Add(new ListItem { Text = item });
        }
        else
        {
            dropDown.Items.Remove(dropDown.Items.FindByText(item));
        }
        
    }

    private void EnableItemAtAllDropdown(bool enabled, string item, DropDownList ignoredDropdown)
    {
        foreach (DropDownList dropDown in dropDowns)
        {
            if(dropDown != ignoredDropdown)
            {
                DropdownEnableItem(enabled, dropDown, item);
            }
        }
    }
    

    protected void UsedDropdron(object sender, EventArgs e)
    {
        DropDownList dropDown = (DropDownList)sender;
        if(KursGenerator.kurse.Find(r => r.name == dropDown.SelectedItem.Text) != null)
        {
            KursGenerator.kurse.Find(r => r.name == dropDown.SelectedItem.Text).choosen = true;
            EnableItemAtAllDropdown(false, dropDown.SelectedItem.Text, dropDown);
        }
        else
        {
            EnableItemAtAllDropdown(true, e.ToString(), dropDown);
        }
    }
}


#region KursGenerator
public static class KursGenerator
{
    public static int pageLoadCounter = 0;


    #region Defined Kurse



    static Kurs deutsch = new Kurs("Deutsch");
    static Kurs mathe = new Kurs("Mathe");
    static Kurs englisch = new Kurs("Englisch");
    static Kurs bildeneKunst = new Kurs("Bildene Kunst");
    static Kurs biologie = new Kurs("Biologie");
    static Kurs chemie = new Kurs("Chemie");
    static Kurs politikWissenschaft = new Kurs("Politikwissenschaft");
    static Kurs geographie = new Kurs("Geographie");
    static Kurs russisch = new Kurs("Russisch");
    static Kurs darstellendesSpiel = new Kurs("Darstellendes Spiel");

    public static List<Kurs> kurse = new List<Kurs>
    {
        deutsch, mathe, englisch, bildeneKunst, biologie, chemie, politikWissenschaft, geographie, russisch, darstellendesSpiel
    };

    #endregion


    public static List<Kurs> LK1 = new List<Kurs> { deutsch, mathe, englisch };
    public static List<Kurs> LK2 = new List<Kurs> { deutsch, mathe, englisch, bildeneKunst, chemie, biologie };
    public static List<Kurs> sGK1 = new List<Kurs> { politikWissenschaft, geographie };
    public static List<Kurs> sGK2 = new List<Kurs> { mathe, deutsch, englisch, politikWissenschaft, geographie, bildeneKunst, chemie, biologie};
    public static List<Kurs> mGK1 = new List<Kurs> { russisch };
    public static List<Kurs> mGK2 = new List<Kurs> { deutsch, englisch };
    public static List<Kurs> AK1 = new List<Kurs> { deutsch, mathe, englisch, darstellendesSpiel, politikWissenschaft, geographie };
    public static List<Kurs> AK2 = new List<Kurs> { deutsch, mathe, englisch, darstellendesSpiel, politikWissenschaft, geographie };

    public static Kurs selectedLK1 = null;
    public static Kurs selectedLK2 = null;
    public static Kurs selectedMGK1 = null;
    public static Kurs selectedMKG2 = null;
    public static Kurs selectedSGK1 = null;
    public static Kurs selectedSGK2 = null;
    public static Kurs selectedAK1 = null;
    public static Kurs selectedAK2 = null;


    public static void ActivateAllKurse()
    {
        foreach (Kurs kurs in kurse)
        {
            kurs.choosen = false;
        }
    }



}








#region KursClasses
public class Kurs
{
    public string name;
    public bool choosen = false;
    public Kurs(string NAME)
    {
        name = NAME;
    }
}


public enum Kurse
{
    Leistungskurs1,
    Leistungskurs2,
    schriftGrundkurs1,
    schriftGrundkurs2,
    mundGrundkurs1,
    mundGrundkurs2,
    Anrechnungskurs1,
    Anrechnungskurs2
}

#endregion
#endregion