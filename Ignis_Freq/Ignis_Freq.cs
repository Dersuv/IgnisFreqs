using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Npgsql;

namespace Ignis_Freq
{
    public partial class Ignis_Freq : Form
    {
        public Ignis_Freq()
        {
            InitializeComponent();
            
            updateCoquinn();
            updateTotalFreq();
            update_TotalNoOfStats();
            UpdateWSP();
            Calculate_StaHp251_Rank();
            Calculate_StaWis251_Rank();
            Calculate_StaPatt251_Rank();
            Calculate_StrPatt251_Rank();
            Calculate_DexPatt251_Rank();
            Calculate_IntMatt251_Rank();
            Calculate_IntMatt_Rank();

        }
        //Coquinn is updated in a code, because it is an alt character used by two people, therefore the frequence for this character is total frequence of Vaxin ans Souris divided by two
        public void updateCoquinn()
        {
            double FirstCoquinn;
            double SecondCoquinn;
            double ThirdCoquinn;
            double FourthCoquinn;
            double FifthCoquinn;
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string FirstVax = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkFirstBoss1 = new NpgsqlCommand(FirstVax, cn);
            int Boss1_Vax = Convert.ToInt32(checkFirstBoss1.ExecuteScalar().ToString());
            string SecondVax = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkSecondBoss1 = new NpgsqlCommand(SecondVax, cn);
            int Boss2_Vax = Convert.ToInt32(checkSecondBoss1.ExecuteScalar().ToString());
            string ThirdVax = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkThirdBoss1 = new NpgsqlCommand(ThirdVax, cn);
            int Boss3_Vax = Convert.ToInt32(checkThirdBoss1.ExecuteScalar().ToString());
            string FourthVax = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkFourthBoss1 = new NpgsqlCommand(FourthVax, cn);
            int Boss4_Vax = Convert.ToInt32(checkFourthBoss1.ExecuteScalar().ToString());
            string FifthVax = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Vaxin'";
            NpgsqlCommand checkFifthBoss1 = new NpgsqlCommand(FifthVax, cn);
            int Boss5_Vax = Convert.ToInt32(checkFifthBoss1.ExecuteScalar().ToString());

            string FirstSou = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkFirstBoss2 = new NpgsqlCommand(FirstSou, cn);
            int Boss1_Sou = Convert.ToInt32(checkFirstBoss2.ExecuteScalar().ToString());
            string SecondSou = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkSecondBoss2 = new NpgsqlCommand(SecondSou, cn);
            int Boss2_Sou = Convert.ToInt32(checkSecondBoss2.ExecuteScalar().ToString());
            string ThirdSou = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkThirdBoss2 = new NpgsqlCommand(ThirdSou, cn);
            int Boss3_Sou = Convert.ToInt32(checkThirdBoss2.ExecuteScalar().ToString());
            string FourthSou = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkFourthBoss2 = new NpgsqlCommand(FourthSou, cn);
            int Boss4_Sou = Convert.ToInt32(checkFourthBoss2.ExecuteScalar().ToString());
            string FifthSou = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = 'Souris'";
            NpgsqlCommand checkFifthBoss2 = new NpgsqlCommand(FifthSou, cn);
            int Boss5_Sou = Convert.ToInt32(checkFifthBoss2.ExecuteScalar().ToString());

            FirstCoquinn = ((double)Boss1_Sou + (double)Boss1_Vax) / (double)2;
            SecondCoquinn = ((double)Boss2_Sou + (double)Boss2_Vax) / (double)2;
            ThirdCoquinn = ((double)Boss3_Sou + (double)Boss3_Vax) / (double)2;
            FourthCoquinn = ((double)Boss4_Sou + (double)Boss4_Vax) / (double)2;
            FifthCoquinn = ((double)Boss5_Sou + (double)Boss5_Vax) / (double)2;
            int FirstCoquinn1 = Convert.ToInt32(Math.Round(FirstCoquinn, MidpointRounding.AwayFromZero));
            int SecondCoquinn1 = Convert.ToInt32(Math.Round(SecondCoquinn, MidpointRounding.AwayFromZero));
            int ThirdCoquinn1 = Convert.ToInt32(Math.Round(ThirdCoquinn, MidpointRounding.AwayFromZero));
            int FourthCoquinn1 = Convert.ToInt32(Math.Round(FourthCoquinn, MidpointRounding.AwayFromZero));
            int FifthCoquinn1 = Convert.ToInt32(Math.Round(FifthCoquinn, MidpointRounding.AwayFromZero));

            NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"First Boss\" = " + FirstCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd1.Connection = cn;
            cmd1.ExecuteNonQuery();

            NpgsqlCommand cmd2 = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Second Boss\" = " + SecondCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd2.Connection = cn;
            cmd2.ExecuteNonQuery();

            NpgsqlCommand cmd3 = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Third Boss\" = " + ThirdCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd3.Connection = cn;
            cmd3.ExecuteNonQuery();

            NpgsqlCommand cmd4 = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Fourth Boss\" = " + FourthCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd4.Connection = cn;
            cmd4.ExecuteNonQuery();

            NpgsqlCommand cmd5 = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Fifth Boss\" = " + FifthCoquinn1 + " Where \"Nickname\" ='Coquinn'");
            cmd5.Connection = cn;
            cmd5.ExecuteNonQuery();
            cn.Close();
        }

        public void UpdateWSP()
        {
            List<float> WSP_Data = new List<float>();
            List<float> LogGold_Data = new List<float>();
            List<float> LogStat_Data = new List<float>();
            
            List<float> Rank_StaHp251 = new List<float>();
            List<float> Rank_StaWis251 = new List<float>();
            List<float> Rank_StaPatt251 = new List<float>();
            List<float> Rank_StrPatt251 = new List<float>();
            List<float> Rank_DexPatt251 = new List<float>();
            List<float> Rank_IntMatt251 = new List<float>();
            List<float> Rank_IntMatt = new List<float>();
            float total_WSP = 0;
            float total_Gold = 0;
            float total_Stat = 0;

            float getRank_StaHp251 = 0;
            float getRank_StaWis251 = 0;
            float getRank_StaPatt251 = 0;
            float getRank_StrPatt251 = 0;
            float getRank_DexPatt251 = 0;
            float getRank_IntMatt251 = 0;
            float getRank_IntMatt = 0;
            NpgsqlConnection cn= new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();

            //Query to calculate Total Guild Frequency
            string WSP_Query = "SELECT \"Total\" FROM public.\"IBP\"";
            using (NpgsqlCommand command = new NpgsqlCommand(WSP_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WSP_Data.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < WSP_Data.Count; c++)
            {

                total_WSP = total_WSP + WSP_Data[c];
            }
            string CoqTotal = "Select \"Total\" from  public.\"IBP\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqTotal = new NpgsqlCommand(CoqTotal, cn);
            float TotalCoq = float.Parse(getCoqTotal.ExecuteScalar().ToString());
            total_WSP = total_WSP - TotalCoq;
            NpgsqlCommand cmd1 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + total_WSP + " Where \"WSP_Name\" ='WSP'");
            cmd1.Connection = cn;
            cmd1.ExecuteNonQuery();

            //Query to calculate Total Gold_Logarithm
            string LogGold_Query = "SELECT \"Gold-Logarithm\" FROM public.\"IBP\"";
            using (NpgsqlCommand command = new NpgsqlCommand(LogGold_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogGold_Data.Add(reader.GetFloat(0));
                        
                    }
                }
            }
            for (var c = 0; c < LogGold_Data.Count; c++)
            {

                total_Gold = total_Gold + LogGold_Data[c];
            }
            string CoqGold = "Select \"Gold-Logarithm\" from  public.\"IBP\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqGold = new NpgsqlCommand(CoqGold, cn);
            float GoldCoq = float.Parse(getCoqGold.ExecuteScalar().ToString());
            total_Gold = total_Gold - GoldCoq;
            NpgsqlCommand Update_GoldLogarithm = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + total_Gold + " Where \"WSP_Name\" ='LogGold'");
            Update_GoldLogarithm.Connection = cn;
            Update_GoldLogarithm.ExecuteNonQuery();

            //Query to calculate Total Stat_Logarithm
            string LogStat_Query = "SELECT \"Stat-Logarithm\" FROM public.\"IBP\"";
            using (NpgsqlCommand command = new NpgsqlCommand(LogStat_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LogStat_Data.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < LogStat_Data.Count; c++)
            {

                total_Stat = total_Stat + LogStat_Data[c];
            }
            string CoqStat = "Select \"Stat-Logarithm\" from  public.\"IBP\" Where \"Nickname\" = 'Coquinn'";
            NpgsqlCommand getCoqStat = new NpgsqlCommand(CoqStat, cn);
            float StatCoq = float.Parse(getCoqStat.ExecuteScalar().ToString());
            total_Stat = total_Stat - StatCoq;
            NpgsqlCommand Update_StatLogarithm = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + total_Stat + " Where \"WSP_Name\" ='LogStat'");
            Update_StatLogarithm.Connection = cn;
            Update_StatLogarithm.ExecuteNonQuery();

            

            //Query to calculate Total Logarithm for sta/hp 251 stats
            string Rank_StaHp251_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaHp251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaHp251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaHp251.Count; c++)
            {
                getRank_StaHp251 = getRank_StaHp251 + Rank_StaHp251[c];
            }
            NpgsqlCommand Update_Total_StaHp251_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_StaHp251 + " Where \"WSP_Name\" ='Log_sta/hp 251'");
            Update_Total_StaHp251_Log.Connection = cn;
            Update_Total_StaHp251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for sta/wis 251 stats
            string Rank_StaWis251_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaWis251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaWis251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaWis251.Count; c++)
            {
                getRank_StaWis251 = getRank_StaWis251 + Rank_StaWis251[c];
            }
            NpgsqlCommand Update_Total_StaWis251_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_StaWis251 + " Where \"WSP_Name\" ='Log_sta/wis 251'");
            Update_Total_StaWis251_Log.Connection = cn;
            Update_Total_StaWis251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for sta/patt 251 stats
            string Rank_StaPatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StaPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StaPatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StaPatt251.Count; c++)
            {
                getRank_StaPatt251 = getRank_StaPatt251 + Rank_StaPatt251[c];
            }
            NpgsqlCommand Update_Total_StaPatt251_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_StaPatt251 + " Where \"WSP_Name\" ='Log_sta/patt 251'");
            Update_Total_StaPatt251_Log.Connection = cn;
            Update_Total_StaPatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for str/patt 251 stats
            string Rank_StrPatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_StrPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_StrPatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_StrPatt251.Count; c++)
            {
                getRank_StrPatt251 = getRank_StrPatt251 + Rank_StrPatt251[c];
            }
            NpgsqlCommand Update_Total_StrPatt251_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_StrPatt251 + " Where \"WSP_Name\" ='Log_str/patt 251'");
            Update_Total_StrPatt251_Log.Connection = cn;
            Update_Total_StrPatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for dex/patt 251 stats
            string Rank_DexPatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Rouge','Scout') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_DexPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_DexPatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_DexPatt251.Count; c++)
            {
                getRank_DexPatt251 = getRank_DexPatt251 + Rank_DexPatt251[c];
            }
            NpgsqlCommand Update_Total_DexPatt251_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_DexPatt251 + " Where \"WSP_Name\" ='Log_dex/patt 251'");
            Update_Total_DexPatt251_Log.Connection = cn;
            Update_Total_DexPatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for int/matt 251 stats
            string Rank_IntMatt251_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Mage','Warlock') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_IntMatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_IntMatt251.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_IntMatt251.Count; c++)
            {
                getRank_IntMatt251 = getRank_IntMatt251 + Rank_IntMatt251[c];
            }
            NpgsqlCommand Update_Total_IntMatt251_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_IntMatt251 + " Where \"WSP_Name\" ='Log_int/matt 251'");
            Update_Total_IntMatt251_Log.Connection = cn;
            Update_Total_IntMatt251_Log.ExecuteNonQuery();

            //Query to calculate Total Logarithm for int/matt stats
            string Rank_IntMatt_Query = "SELECT \"Stat-Logarithm\" From public.\"IBP\", public.\"People\" Where \"Class\" in ('Mage','Warlock') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Rank_IntMatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Rank_IntMatt.Add(reader.GetFloat(0));
                    }
                }
            }
            for (var c = 0; c < Rank_IntMatt.Count; c++)
            {
                getRank_IntMatt = getRank_IntMatt + Rank_IntMatt[c];
            }
            NpgsqlCommand Update_Total_IntMatt_Log = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + getRank_IntMatt + " Where \"WSP_Name\" ='Log_int/matt'");
            Update_Total_IntMatt_Log.Connection = cn;
            Update_Total_IntMatt_Log.ExecuteNonQuery();

            cn.Close();
        }
        public void update_TotalNoOfStats()
        {
            List<int> Total_StaHp251 = new List<int>();
            List<int> Total_StaWis251 = new List<int>();
            List<int> Total_StaPatt251 = new List<int>();
            List<int> Total_StrPatt251 = new List<int>();
            List<int> Total_DexPatt251 = new List<int>();
            List<int> Total_IntMatt251 = new List<int>();
            List<int> Total_IntMatt = new List<int>();

            int totalStat_StaHp251 = 0;
            int totalStat_StaWis51 = 0;
            int totalStat_StaPatt251 = 0;
            int totalStat_StrPatt251 = 0;
            int totalStat_DexPatt251 = 0;
            int totalStat_IntMatt251 = 0;
            int totalStat_IntMatt = 0;

            NpgsqlConnection cn= new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            //Query to calculate Total sta/hp 251 stats
            string Total_StaHp251_Query = "SELECT \"sta/hp 251\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaHp251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaHp251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaHp251.Count; c++)
            {

                totalStat_StaHp251 = totalStat_StaHp251 + Total_StaHp251[c];
            }
            NpgsqlCommand Update_Total_StaHp251 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_StaHp251 + " Where \"WSP_Name\" ='sta/hp 251'");
            Update_Total_StaHp251.Connection = cn;
            Update_Total_StaHp251.ExecuteNonQuery();

            //Query to calculate Total sta/wis 251 stats
            string Total_StaWis251_Query = "SELECT \"sta/wis 251\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaWis251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaWis251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaWis251.Count; c++)
            {

                totalStat_StaWis51 = totalStat_StaWis51 + Total_StaWis251[c];
            }
            NpgsqlCommand Update_Total_StaWis251 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_StaWis51 + " Where \"WSP_Name\" ='sta/wis 251'");
            Update_Total_StaWis251.Connection = cn;
            Update_Total_StaWis251.ExecuteNonQuery();

            //Query to calculate Total sta/patt 251 stats
            string Total_StaPatt251_Query = "SELECT \"sta/patt 251\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StaPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StaPatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StaPatt251.Count; c++)
            {

                totalStat_StaPatt251 = totalStat_StaPatt251 + Total_StaPatt251[c];
            }
            NpgsqlCommand Update_Total_StaPatt251 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_StaPatt251 + " Where \"WSP_Name\" ='sta/patt 251'");
            Update_Total_StaPatt251.Connection = cn;
            Update_Total_StaPatt251.ExecuteNonQuery();

            //Query to calculate Total str/patt 251 stats
            string Total_StrPatt251_Query = "SELECT \"str/patt 251\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_StrPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_StrPatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_StrPatt251.Count; c++)
            {

                totalStat_StrPatt251 = totalStat_StrPatt251 + Total_StrPatt251[c];
            }
            NpgsqlCommand Update_Total_StrPatt251 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_StrPatt251 + " Where \"WSP_Name\" ='str/patt 251'");
            Update_Total_StrPatt251.Connection = cn;
            Update_Total_StrPatt251.ExecuteNonQuery();

            //Query to calculate Total dex/patt 251 stats
            string Total_DexPatt251_Query = "SELECT \"dex/patt 251\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_DexPatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_DexPatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_DexPatt251.Count; c++)
            {

                totalStat_DexPatt251 = totalStat_DexPatt251 + Total_DexPatt251[c];
            }
            NpgsqlCommand Update_Total_DexPatt251 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_DexPatt251 + " Where \"WSP_Name\" ='dex/patt 251'");
            Update_Total_DexPatt251.Connection = cn;
            Update_Total_DexPatt251.ExecuteNonQuery();

            //Query to calculate Total int/matt 251 stats
            string Total_IntMatt251_Query = "SELECT \"int/matt 251\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_IntMatt251_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_IntMatt251.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_IntMatt251.Count; c++)
            {

                totalStat_IntMatt251 = totalStat_IntMatt251 + Total_IntMatt251[c];
            }
            NpgsqlCommand Update_Total_IntMatt251 = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_IntMatt251 + " Where \"WSP_Name\" ='int/matt 251'");
            Update_Total_IntMatt251.Connection = cn;
            Update_Total_IntMatt251.ExecuteNonQuery();

            //Query to calculate Total int/matt stats
            string Total_IntMatt_Query = "SELECT \"int/matt\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(Total_IntMatt_Query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Total_IntMatt.Add(reader.GetInt32(0));
                    }
                }
            }
            for (var c = 0; c < Total_IntMatt.Count; c++)
            {

                totalStat_IntMatt = totalStat_IntMatt + Total_IntMatt[c];
            }
            NpgsqlCommand Update_Total_IntMatt = new NpgsqlCommand("UPDATE public.\"WSP\" SET \"WSP\" = " + totalStat_IntMatt + " Where \"WSP_Name\" ='int/matt'");
            Update_Total_IntMatt.Connection = cn;
            Update_Total_IntMatt.ExecuteNonQuery();

            cn.Close();
        }
        public void updateTotalFreq()
        {
            List<String> columnData = new List<String>();

           NpgsqlConnection cn= new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string query = "SELECT \"Nickname\" FROM public.\"IBP\"";
            using (NpgsqlCommand command = new NpgsqlCommand(query, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        columnData.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();

            columnData = columnData.Select(t => Regex.Replace(t, @"\s+", "")).ToList();
            for (var i = 0; i < columnData.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + columnData[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);
                NpgsqlCommand cmd = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Total\" = " + totalFreq + " Where \"Nickname\" ='" + columnData[i] + "' ");
                cmd.Connection = cn;
                cmd.ExecuteNonQuery();

                NpgsqlCommand update_LogGold = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Gold-Logarithm\" = " + goldLog + " Where \"Nickname\" ='" + columnData[i] + "' ");
                update_LogGold.Connection = cn;
                update_LogGold.ExecuteNonQuery();

                NpgsqlCommand update_LogStat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Stat-Logarithm\" = " + statLog + " Where \"Nickname\" ='" + columnData[i] + "' ");
                update_LogStat.Connection = cn;
                update_LogStat.ExecuteNonQuery();
                
                cn.Close();

            }

            }
        public void Calculate_StaHp251_Rank()
        {
            List<String> PeopleForStaHP251 = new List<String>();
            NpgsqlConnection cn= new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForStaHP = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Knight', 'Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaHP, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaHP251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaHP251.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaHp251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'sta/hp 251'";
                NpgsqlCommand Total_StaHp251 = new NpgsqlCommand(getTotal_StaHp251, cn);
                decimal total1 = Convert.ToDecimal(Total_StaHp251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaHp251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_sta/hp 251'";
                NpgsqlCommand Total_Log_StaHp251 = new NpgsqlCommand(getTotal_Log_StaHp251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaHp251.ExecuteScalar().ToString());

                string getUser_StaHp251 = "SELECT \"sta/hp 251\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaHP251[i] + "'";
                NpgsqlCommand user_StaHP251 = new NpgsqlCommand(getUser_StaHp251, cn);
                int user_StaHp251No = Convert.ToInt32(user_StaHP251.ExecuteScalar().ToString());

                decimal newRank_StaHp251;
                if(total_Log1 == 0)
                {
                    newRank_StaHp251 = 0;
                }
                else
                {
                    newRank_StaHp251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaHp251No;
                }
                

                NpgsqlCommand update_UserStaHp251_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank1\" = " + newRank_StaHp251 + " Where \"Nickname\" ='" + PeopleForStaHP251[i] + "' ");
                update_UserStaHp251_Log.Connection = cn;
                update_UserStaHp251_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Calculate_StaWis251_Rank()
        {
            List<String> PeopleForStaWis251 = new List<String>();
            NpgsqlConnection cn= new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForStaWis = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Priest', 'Druid') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaWis, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaWis251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaWis251.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaWis251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'sta/wis 251'";
                NpgsqlCommand Total_StaWis251 = new NpgsqlCommand(getTotal_StaWis251, cn);
                decimal total1 = Convert.ToDecimal(Total_StaWis251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaWis251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_sta/wis 251'";
                NpgsqlCommand Total_Log_StaWis251 = new NpgsqlCommand(getTotal_Log_StaWis251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaWis251.ExecuteScalar().ToString());

                string getUser_StaWis251 = "SELECT \"sta/wis 251\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaWis251[i] + "'";
                NpgsqlCommand user_StaWis251 = new NpgsqlCommand(getUser_StaWis251, cn);
                int user_StaWis251No = Convert.ToInt32(user_StaWis251.ExecuteScalar().ToString());

                decimal newRank_StaWis251;
                if (total_Log1 == 0)
                {
                    newRank_StaWis251 = 0;
                }
                else
                {
                    newRank_StaWis251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaWis251No;
                }
                

                NpgsqlCommand update_UserStaWis251_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank2\" = " + newRank_StaWis251 + " Where \"Nickname\" ='" + PeopleForStaWis251[i] + "' ");
                update_UserStaWis251_Log.Connection = cn;
                update_UserStaWis251_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Calculate_StaPatt251_Rank()
        {
            List<String> PeopleForStaPatt251 = new List<String>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForStaPatt = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Knight') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStaPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStaPatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStaPatt251.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StaPatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'sta/patt 251'";
                NpgsqlCommand Total_StaPatt251 = new NpgsqlCommand(getTotal_StaPatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_StaPatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StaPatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_sta/patt 251'";
                NpgsqlCommand Total_Log_StaPatt251 = new NpgsqlCommand(getTotal_Log_StaPatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StaPatt251.ExecuteScalar().ToString());

                string getUser_StaPatt251 = "SELECT \"sta/patt 251\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForStaPatt251[i] + "'";
                NpgsqlCommand user_StaPatt251 = new NpgsqlCommand(getUser_StaPatt251, cn);
                int user_StaPatt251No = Convert.ToInt32(user_StaPatt251.ExecuteScalar().ToString());

                decimal newRank_StaPatt251;
                if (total_Log1 == 0)
                {
                    newRank_StaPatt251 = 0;
                }
                else
                {
                    newRank_StaPatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StaPatt251No;
                }

                NpgsqlCommand update_UserStaPatt251_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank3\" = " + newRank_StaPatt251 + " Where \"Nickname\" ='" + PeopleForStaPatt251[i] + "' ");
                update_UserStaPatt251_Log.Connection = cn;
                update_UserStaPatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Calculate_StrPatt251_Rank()
        {
            List<String> PeopleForStrPatt251 = new List<String>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForStrPatt = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Warden', 'Champion', 'Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForStrPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForStrPatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForStrPatt251.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_StrPatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'str/patt 251'";
                NpgsqlCommand Total_StrPatt251 = new NpgsqlCommand(getTotal_StrPatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_StrPatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_StrPatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_str/patt 251'";
                NpgsqlCommand Total_Log_StrPatt251 = new NpgsqlCommand(getTotal_Log_StrPatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_StrPatt251.ExecuteScalar().ToString());

                string getUser_StrPatt251 = "SELECT \"str/patt 251\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForStrPatt251[i] + "'";
                NpgsqlCommand user_StrPatt251 = new NpgsqlCommand(getUser_StrPatt251, cn);
                int user_StrPatt251No = Convert.ToInt32(user_StrPatt251.ExecuteScalar().ToString());

                decimal newRank_StrPatt251;
                if (total_Log1 == 0)
                {
                    newRank_StrPatt251 = 0;
                }
                else
                {
                    newRank_StrPatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_StrPatt251No;
                }
                
                NpgsqlCommand update_UserStrPatt251_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank4\" = " + newRank_StrPatt251 + " Where \"Nickname\" ='" + PeopleForStrPatt251[i] + "' ");
                update_UserStrPatt251_Log.Connection = cn;
                update_UserStrPatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Calculate_DexPatt251_Rank()
        {
            List<String> PeopleForDexPatt251 = new List<String>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForDexPatt = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Rouge', 'Scout') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForDexPatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForDexPatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForDexPatt251.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_DexPatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'dex/patt 251'";
                NpgsqlCommand Total_DexPatt251 = new NpgsqlCommand(getTotal_DexPatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_DexPatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_DexPatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_dex/patt 251'";
                NpgsqlCommand Total_Log_DexPatt251 = new NpgsqlCommand(getTotal_Log_DexPatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_DexPatt251.ExecuteScalar().ToString());

                string getUser_DexPatt251 = "SELECT \"dex/patt 251\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForDexPatt251[i] + "'";
                NpgsqlCommand user_DexPatt251 = new NpgsqlCommand(getUser_DexPatt251, cn);
                int user_DexPatt251No = Convert.ToInt32(user_DexPatt251.ExecuteScalar().ToString());

                decimal newRank_DexPatt251;
                if (total_Log1 == 0)
                {
                    newRank_DexPatt251 = 0;
                }
                else
                {
                    newRank_DexPatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_DexPatt251No;
                }
                

                NpgsqlCommand update_UserDexPatt251_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank5\" = " + newRank_DexPatt251 + " Where \"Nickname\" ='" + PeopleForDexPatt251[i] + "' ");
                update_UserDexPatt251_Log.Connection = cn;
                update_UserDexPatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Calculate_IntMatt251_Rank()
        {
            List<String> PeopleForIntMatt251 = new List<String>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForIntMatt = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForIntMatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForIntMatt251.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForIntMatt251.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_IntMatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'int/matt 251'";
                NpgsqlCommand Total_IntMatt251 = new NpgsqlCommand(getTotal_IntMatt251, cn);
                decimal total1 = Convert.ToDecimal(Total_IntMatt251.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_IntMatt251 = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_int/matt 251'";
                NpgsqlCommand Total_Log_IntMatt251 = new NpgsqlCommand(getTotal_Log_IntMatt251, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_IntMatt251.ExecuteScalar().ToString());

                string getUser_IntMatt251 = "SELECT \"int/matt 251\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt251[i] + "'";
                NpgsqlCommand user_IntMatt251 = new NpgsqlCommand(getUser_IntMatt251, cn);
                int user_IntMatt251No = Convert.ToInt32(user_IntMatt251.ExecuteScalar().ToString());

                decimal newRank_IntMatt251;
                if (total_Log1 == 0)
                {
                    newRank_IntMatt251 = 0;
                }
                else
                {
                    newRank_IntMatt251 = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_IntMatt251No;
                }


                NpgsqlCommand update_UserIntMatt251_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank6\" = " + newRank_IntMatt251 + " Where \"Nickname\" ='" + PeopleForIntMatt251[i] + "' ");
                update_UserIntMatt251_Log.Connection = cn;
                update_UserIntMatt251_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        public void Calculate_IntMatt_Rank()
        {
            List<String> PeopleForIntMatt = new List<String>();
            NpgsqlConnection cn = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
            cn.Open();
            string getPeopleForIntMatt = "SELECT public.\"IBP\".\"Nickname\" FROM public.\"IBP\", public.\"People\" Where \"Class\" in ('Mage', 'Warlock') AND public.\"People\".\"Nickname\" = public.\"IBP\".\"Nickname\"";
            using (NpgsqlCommand command = new NpgsqlCommand(getPeopleForIntMatt, cn))
            {
                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PeopleForIntMatt.Add(reader.GetString(0));
                    }
                }
            }
            cn.Close();
            for (var i = 0; i < PeopleForIntMatt.Count; i++)
            {
                cn.Open();
                string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());

                string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());

                string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());

                string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());

                string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());

                double totalFreq = (1 * temp) + (1.2 * temp2) + (1.4 * temp3) + (1.3 * temp4) + (1.1 * temp5);
                double goldLog = 80 * Math.Log10((totalFreq + 80) / 80);
                goldLog = Math.Round(goldLog, 2);

                double statLog = Math.Log10(totalFreq + 1);
                statLog = Math.Round(statLog, 2);


                string getTotal_IntMatt = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'int/matt'";
                NpgsqlCommand Total_IntMatt = new NpgsqlCommand(getTotal_IntMatt, cn);
                decimal total1 = Convert.ToDecimal(Total_IntMatt.ExecuteScalar().ToString());
                Convert.ToInt32(total1);
                string getTotal_Log_IntMatt = "Select \"WSP\" from  public.\"WSP\" Where \"WSP_Name\" = 'Log_int/matt'";
                NpgsqlCommand Total_Log_IntMatt = new NpgsqlCommand(getTotal_Log_IntMatt, cn);
                decimal total_Log1 = Convert.ToDecimal(Total_Log_IntMatt.ExecuteScalar().ToString());

                string getUser_IntMatt = "SELECT \"int/matt\" FROM public.\"IBP\" Where \"Nickname\" = '" + PeopleForIntMatt[i] + "'";
                NpgsqlCommand user_IntMatt = new NpgsqlCommand(getUser_IntMatt, cn);
                int user_IntMattNo = Convert.ToInt32(user_IntMatt.ExecuteScalar().ToString());

                decimal newRank_IntMatt;
                if (total_Log1 == 0)
                {
                    newRank_IntMatt = 0;
                }
                else
                {
                    newRank_IntMatt = (decimal)statLog / ((decimal)total_Log1 / (total1 + 1)) - user_IntMattNo;
                }
                

                NpgsqlCommand update_UserIntMatt_Log = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"rank7\" = " + newRank_IntMatt + " Where \"Nickname\" ='" + PeopleForIntMatt[i] + "' ");
                update_UserIntMatt_Log.Connection = cn;
                update_UserIntMatt_Log.ExecuteNonQuery();
                cn.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialofResult = new DialogResult();
            dialofResult = MessageBox.Show("Do you want to Close the application?","Exit",MessageBoxButtons.YesNo);
            if (dialofResult == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }
        public void btn_Submit_Click(object sender, EventArgs e)
        {
            SaveFrequency();            
        }
        
        public  void SaveFrequency()
        {
            //Variables declaration
            #region Variables
            string RaidTitle = txt_Title.Text;
            string FirstMamber = txt_Member1.Text;
            string SecondMember = txt_Member2.Text;
            string ThirdMember = txt_Member3.Text;
            string FourthMember = txt_Member4.Text;
            string FifthMember = txt_Member5.Text;
            string SixthMember = txt_Member6.Text;
            string SeventhMember = txt_Member7.Text;
            string EightMember = txt_Member8.Text;
            string NinthMember = txt_Member9.Text;
            string TenthMember = txt_Member10.Text;
            string EleventhMember = txt_Member11.Text;
            string TwelfthMember = txt_Member12.Text;
            string FirstReserve = txt_Reserve1.Text;
            string SecondReserve = txt_Reserve2.Text;
            string ThirdReserve = txt_Reserve3.Text;
            string FourthReserve = txt_Reserve4.Text;
            string FifthReserve = txt_Reserve5.Text;
            string FirstFreq; string FirstFreqV;
            string FirstFreq1; string FirstFreqV1;
            string FirstFreq2; string FirstFreqV2;
            string FirstFreq3; string FirstFreqV3;
            string FirstFreq4; string FirstFreqV4;
            string FirstFreq5; string FirstFreqV5;
            string SecondFreq; string SecondFreqV;
            string SecondFreq1; string SecondFreqV1;
            string SecondFreq2; string SecondFreqV2;
            string SecondFreq3; string SecondFreqV3;
            string SecondFreq4; string SecondFreqV4;
            string SecondFreq5; string SecondFreqV5;
            string ThirdFreq; string ThirdFreqV;
            string ThirdFreq1; string ThirdFreqV1;
            string ThirdFreq2; string ThirdFreqV2;
            string ThirdFreq3; string ThirdFreqV3;
            string ThirdFreq4; string ThirdFreqV4;
            string ThirdFreq5; string ThirdFreqV5;
            string FourthFreq; string FourthFreqV;
            string FourthFreq1; string FourthFreqV1;
            string FourthFreq2; string FourthFreqV2;
            string FourthFreq3; string FourthFreqV3;
            string FourthFreq4; string FourthFreqV4;
            string FourthFreq5; string FourthFreqV5;
            string FifthFreq; string FifthFreqV;
            string FifthFreq1; string FifthFreqV1;
            string FifthFreq2; string FifthFreqV2;
            string FifthFreq3; string FifthFreqV3;
            string FifthFreq4; string FifthFreqV4;
            string FifthFreq5; string FifthFreqV5;
            string SixthFreq; string SixthFreqV;
            string SixthFreq1; string SixthFreqV1;
            string SixthFreq2; string SixthFreqV2;
            string SixthFreq3; string SixthFreqV3;
            string SixthFreq4; string SixthFreqV4;
            string SixthFreq5; string SixthFreqV5;
            string SeventhFreq; string SeventhFreqV;
            string SeventhFreq1; string SeventhFreqV1;
            string SeventhFreq2; string SeventhFreqV2;
            string SeventhFreq3; string SeventhFreqV3;
            string SeventhFreq4; string SeventhFreqV4;
            string SeventhFreq5; string SeventhFreqV5;
            string EightFreq; string EightFreqV;
            string EightFreq1; string EightFreqV1;
            string EightFreq2; string EightFreqV2;
            string EightFreq3; string EightFreqV3;
            string EightFreq4; string EightFreqV4;
            string EightFreq5; string EightFreqV5;
            string NinthFreq; string NinthFreqV;
            string NinthFreq1; string NinthFreqV1;
            string NinthFreq2; string NinthFreqV2;
            string NinthFreq3; string NinthFreqV3;
            string NinthFreq4; string NinthFreqV4;
            string NinthFreq5; string NinthFreqV5;
            string TenthFreq; string TenthFreqV;
            string TenthFreq1; string TenthFreqV1;
            string TenthFreq2; string TenthFreqV2;
            string TenthFreq3; string TenthFreqV3;
            string TenthFreq4; string TenthFreqV4;
            string TenthFreq5; string TenthFreqV5;
            string EleventhFreq; string EleventhFreqV;
            string EleventhFreq1; string EleventhFreqV1;
            string EleventhFreq2; string EleventhFreqV2;
            string EleventhFreq3; string EleventhFreqV3;
            string EleventhFreq4; string EleventhFreqV4;
            string EleventhFreq5; string EleventhFreqV5;
            string TwelfthFreq; string TwelfthFreqV;
            string TwelfthFreq1; string TwelfthFreqV1;
            string TwelfthFreq2; string TwelfthFreqV2;
            string TwelfthFreq3; string TwelfthFreqV3;
            string TwelfthFreq4; string TwelfthFreqV4;
            string TwelfthFreq5; string TwelfthFreqV5;
            string FirstReserveFreq; string FirstReserveFreqV;
            string FirstReserveFreq1; string FirstReserveFreqV1;
            string FirstReserveFreq2; string FirstReserveFreqV2;
            string FirstReserveFreq3; string FirstReserveFreqV3;
            string FirstReserveFreq4; string FirstReserveFreqV4;
            string FirstReserveFreq5; string FirstReserveFreqV5;
            string SecondReserveFreq; string SecondReserveFreqV;
            string SecondReserveFreq1; string SecondReserveFreqV1;
            string SecondReserveFreq2; string SecondReserveFreqV2;
            string SecondReserveFreq3; string SecondReserveFreqV3;
            string SecondReserveFreq4; string SecondReserveFreqV4;
            string SecondReserveFreq5; string SecondReserveFreqV5;
            string ThirdReserveFreq; string ThirdReserveFreqV;
            string ThirdReserveFreq1; string ThirdReserveFreqV1;
            string ThirdReserveFreq2; string ThirdReserveFreqV2;
            string ThirdReserveFreq3; string ThirdReserveFreqV3;
            string ThirdReserveFreq4; string ThirdReserveFreqV4;
            string ThirdReserveFreq5; string ThirdReserveFreqV5;
            string FourthReserveFreq; string FourthReserveFreqV;
            string FourthReserveFreq1; string FourthReserveFreqV1;
            string FourthReserveFreq2; string FourthReserveFreqV2;
            string FourthReserveFreq3; string FourthReserveFreqV3;
            string FourthReserveFreq4; string FourthReserveFreqV4;
            string FourthReserveFreq5; string FourthReserveFreqV5;
            string FifthReserveFreq; string FifthReserveFreqV;
            string FifthReserveFreq1; string FifthReserveFreqV1;
            string FifthReserveFreq2; string FifthReserveFreqV2;
            string FifthReserveFreq3; string FifthReserveFreqV3;
            string FifthReserveFreq4; string FifthReserveFreqV4;
            string FifthReserveFreq5; string FifthReserveFreqV5;
            string drop1 = txt_Drop1.Text;
            string drop2 = txt_Drop2.Text;
            string drop3 = txt_Drop3.Text;
            string drop4 = txt_Drop4.Text;
            string drop5 = txt_Drop5.Text;
            string drop6 = txt_Drop6.Text;
            string drop7 = txt_Drop7.Text;
            string drop8 = txt_Drop8.Text;
            string drop9 = txt_Drop9.Text;
            string date = DateTime.Now.ToString("dd-MM-yyyy");

            int FirstFreqNo1 = 0;
            int SeconFreqNo1 = 0;
            int ThirdFreqNo1 = 0;
            int FourthFreqNo1 =0;
            int FifthFreqNo1 = 0;

            int FirstFreqNo2 = 0;
            int SeconFreqNo2 = 0;
            int ThirdFreqNo2 = 0;
            int FourthFreqNo2 = 0;
            int FifthFreqNo2 = 0;

            int FirstFreqNo3 = 0;
            int SeconFreqNo3 = 0;
            int ThirdFreqNo3 = 0;
            int FourthFreqNo3 = 0;
            int FifthFreqNo3 = 0;

            int FirstFreqNo4 = 0;
            int SeconFreqNo4 = 0;
            int ThirdFreqNo4 = 0;
            int FourthFreqNo4 = 0;
            int FifthFreqNo4 = 0;

            int FirstFreqNo5 = 0;
            int SeconFreqNo5 = 0;
            int ThirdFreqNo5 = 0;
            int FourthFreqNo5 = 0;
            int FifthFreqNo5 = 0;

            int FirstFreqNo6 = 0;
            int SeconFreqNo6 = 0;
            int ThirdFreqNo6 = 0;
            int FourthFreqNo6 = 0;
            int FifthFreqNo6 = 0;

            int FirstFreqNo7 = 0;
            int SeconFreqNo7 = 0;
            int ThirdFreqNo7 = 0;
            int FourthFreqNo7 = 0;
            int FifthFreqNo7 = 0;

            int FirstFreqNo8 = 0;
            int SeconFreqNo8 = 0;
            int ThirdFreqNo8 = 0;
            int FourthFreqNo8 = 0;
            int FifthFreqNo8 = 0;

            int FirstFreqNo9 = 0;
            int SeconFreqNo9 = 0;
            int ThirdFreqNo9 = 0;
            int FourthFreqNo9 = 0;
            int FifthFreqNo9 = 0;

            int FirstFreqNo10 = 0;
            int SeconFreqNo10 = 0;
            int ThirdFreqNo10 = 0;
            int FourthFreqNo10 = 0;
            int FifthFreqNo10 = 0;

            int FirstFreqNo11 = 0;
            int SeconFreqNo11 = 0;
            int ThirdFreqNo11 = 0;
            int FourthFreqNo11 = 0;
            int FifthFreqNo11 = 0;

            int FirstFreqNo12 = 0;
            int SeconFreqNo12 = 0;
            int ThirdFreqNo12 = 0;
            int FourthFreqNo12 = 0;
            int FifthFreqNo12 = 0;

            int FirstFreqNo13 = 0;
            int SeconFreqNo13 = 0;
            int ThirdFreqNo13 = 0;
            int FourthFreqNo13 = 0;
            int FifthFreqNo13 = 0;

            int FirstFreqNo14 = 0;
            int SeconFreqNo14 = 0;
            int ThirdFreqNo14 = 0;
            int FourthFreqNo14 = 0;
            int FifthFreqNo14 = 0;

            int FirstFreqNo15 = 0;
            int SeconFreqNo15 = 0;
            int ThirdFreqNo15 = 0;
            int FourthFreqNo15 = 0;
            int FifthFreqNo15 = 0;

            int FirstFreqNo16 = 0;
            int SeconFreqNo16 = 0;
            int ThirdFreqNo16 = 0;
            int FourthFreqNo16 = 0;
            int FifthFreqNo16 = 0;

            int FirstFreqNo17 = 0;
            int SeconFreqNo17 = 0;
            int ThirdFreqNo17 = 0;
            int FourthFreqNo17 = 0;
            int FifthFreqNo17 = 0;

            int FirstFreqNo18 = 0;
            int SeconFreqNo18 = 0;
            int ThirdFreqNo18 = 0;
            int FourthFreqNo18 = 0;
            int FifthFreqNo18 = 0;
            #endregion


            //Collect all your TextBox objects in a new list...
            List<TextBox> textBoxes = new List<TextBox>
            {
            txt_Member1, txt_Member2, txt_Member3, txt_Member4, txt_Member5, txt_Member6, txt_Member7, txt_Member8, txt_Member9, txt_Member10, txt_Member11, txt_Member12
            };

            //Use LINQ to count duplicates in the list...
            int dupes = textBoxes.GroupBy(x => x.Text)
                                 .Where(g => g.Count() > 1)
                                 .Count();
            //var emptyTextBox = Controls.OfType().FirstOrDefault(t => string.IsNullOrEmpty(t.Text));
            var emptyTextBox = Controls.OfType<TextBox>().FirstOrDefault(t => string.IsNullOrEmpty(t.Text));

            if (txt_Title.Text == "")
            {
                MessageBox.Show("Please enter the Title of the Raid.");
            }
            else
            {
                    //If there are duplicate nicknames on a list an error message will be displayed, if there are no duplicates the list will be saved to a file
                    if (emptyTextBox == null && dupes > 0)
                    {
                        MessageBox.Show("Please do not duplicate members!");
                    }
                    else
                    {
                        //Assigning value of frequency for the first member
                        #region FirstMember Frequency
                        if (chk_Full1.Checked)
                        {
                            FirstFreq = "Full";
                            FirstFreqV = "X";
                            FirstFreqNo1 = 1;
                            SeconFreqNo1 = 1;
                            ThirdFreqNo1 = 1;
                            FourthFreqNo1 = 1;
                            FifthFreqNo1 = 1;
                        }
                        else
                        {
                            FirstFreq = "";
                            FirstFreqV = "";
                        }
                        if (chk_First1.Checked)
                        {
                            FirstFreq1 = "| 1 |";
                            FirstFreqV1 = "X";
                            FirstFreqNo1 = FirstFreqNo1 + 1;
                        }
                        else
                        {
                            FirstFreq1 = "";
                            FirstFreqV1 = "";
                            FirstFreqNo1 = FirstFreqNo1 + 0;
                        }
                        if (chk_Second1.Checked)
                        {
                            FirstFreq2 = "| 2 |";
                            FirstFreqV2 = "X";
                            SeconFreqNo1 = SeconFreqNo1 + 1;
                        }
                        else
                        {
                            FirstFreq2 = "";
                            FirstFreqV2 = "";
                            SeconFreqNo1 = SeconFreqNo1 +0;
                        }
                        if (chk_Third1.Checked)
                        {
                            FirstFreq3 = "| 3 |";
                            FirstFreqV3 = "X";
                            ThirdFreqNo1 = ThirdFreqNo1 + 1;
                        }
                        else
                        {
                            FirstFreq3 = "";
                            FirstFreqV3 = "";
                            ThirdFreqNo1 = ThirdFreqNo1 + 0;
                        }
                        if (chk_Fourth1.Checked)
                        {
                            FirstFreq4 = "| 4 |";
                            FirstFreqV4 = "X";
                            FourthFreqNo1 = FourthFreqNo1 + 1;
                        }
                        else
                        {
                            FirstFreq4 = "";
                            FirstFreqV4 = "";
                            FourthFreqNo1 = FourthFreqNo1 + 0;
                        }
                        if (chk_Fifth1.Checked)
                        {
                            FirstFreq5 = "| 5 |";
                            FirstFreqV5 = "X";
                            FifthFreqNo1 = FifthFreqNo1 + 1;
                        }
                        else
                        {
                            FirstFreq5 = "";
                            FirstFreqV5 = "";
                            FifthFreqNo1 = FifthFreqNo1 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the second member
                        #region SecondMember Frequency
                        if (chk_Full2.Checked)
                        {
                            SecondFreq = "Full";
                            SecondFreqV = "X";
                            FirstFreqNo2 = 1;
                            SeconFreqNo2 = 1;
                            ThirdFreqNo2 = 1;
                            FourthFreqNo2 = 1;
                            FifthFreqNo2 = 1;
                        }
                        else
                        {
                            SecondFreq = "";
                            SecondFreqV = "";
                        }
                        if (chk_First2.Checked)
                        {
                            SecondFreq1 = "| 1 |";
                            SecondFreqV1 = "X";
                            FirstFreqNo2 = FirstFreqNo2 + 1;
                        }
                        else
                        {
                            SecondFreq1 = "";
                            SecondFreqV1 = "";
                            FirstFreqNo2 = FirstFreqNo2 + 0;
                        }
                        if (chk_Second2.Checked)
                        {
                            SecondFreq2 = "| 2 |";
                            SecondFreqV2 = "X";
                            SeconFreqNo2 = SeconFreqNo2 + 1;
                        }
                        else
                        {
                            SecondFreq2 = "";
                            SecondFreqV2 = "";
                            SeconFreqNo2 = SeconFreqNo2 + 0;
                        }
                        if (chk_Third2.Checked)
                        {
                            SecondFreq3 = "| 3 |";
                            SecondFreqV3 = "X";
                            ThirdFreqNo2 = ThirdFreqNo2 + 1;
                        }
                        else
                        {
                            SecondFreq3 = "";
                            SecondFreqV3 = "";
                            ThirdFreqNo2 = ThirdFreqNo2 + 0;
                        }
                        if (chk_Fourth2.Checked)
                        {
                            SecondFreq4 = "| 4 |";
                            SecondFreqV4 = "X";
                            FourthFreqNo2 = FourthFreqNo2 + 1;
                        }
                        else
                        {
                            SecondFreq4 = "";
                            SecondFreqV4 = "";
                            FourthFreqNo2 = FourthFreqNo2 + 0;
                        }
                        if (chk_Fifth2.Checked)
                        {
                            SecondFreq5 = "| 5 |";
                            SecondFreqV5 = "X";
                            FifthFreqNo2 = FifthFreqNo2 + 1;
                        }
                        else
                        {
                            SecondFreq5 = "";
                            SecondFreqV5 = "";
                            FifthFreqNo2 = FifthFreqNo2 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the third member
                        #region ThirdMember Frequency
                        if (chk_Full3.Checked)
                        {
                            ThirdFreq = "Full";
                            ThirdFreqV = "X";
                            FirstFreqNo3 = 1;
                            SeconFreqNo3 = 1;
                            ThirdFreqNo3 = 1;
                            FourthFreqNo3 = 1;
                            FifthFreqNo3 = 1;
                        }
                        else
                        {
                            ThirdFreq = "";
                            ThirdFreqV = "";
                        }
                        if (chk_First3.Checked)
                        {
                            ThirdFreq1 = "| 1 |";
                            ThirdFreqV1 = "X";
                            FirstFreqNo3 = FirstFreqNo3 + 1;
                        }
                        else
                        {
                            ThirdFreq1 = "";
                            ThirdFreqV1 = "";
                            FirstFreqNo3 = FirstFreqNo3 + 0;
                        }
                        if (chk_Second3.Checked)
                        {
                            ThirdFreq2 = "| 2 |";
                            ThirdFreqV2 = "X";
                            SeconFreqNo3 = SeconFreqNo3 + 1;
                        }
                        else
                        {
                            ThirdFreq2 = "";
                            ThirdFreqV2 = "";
                            SeconFreqNo3 = SeconFreqNo3 + 0;
                        }
                        if (chk_Third3.Checked)
                        {
                            ThirdFreq3 = "| 3 |";
                            ThirdFreqV3 = "X";
                            ThirdFreqNo3 = ThirdFreqNo3 + 1;
                        }
                        else
                        {
                            ThirdFreq3 = "";
                            ThirdFreqV3 = "";
                            ThirdFreqNo3 = ThirdFreqNo3 + 0;
                        }
                        if (chk_Fourth3.Checked)
                        {
                            ThirdFreq4 = "| 4 |";
                            ThirdFreqV4 = "X";
                            FourthFreqNo3 = FourthFreqNo3 + 1;
                        }
                        else
                        {
                            ThirdFreq4 = "";
                            ThirdFreqV4 = "";
                            FourthFreqNo3 = FourthFreqNo3 + 0;
                        }
                        if (chk_Fifth3.Checked)
                        {
                            ThirdFreq5 = "| 5 |";
                            ThirdFreqV5 = "X";
                            FifthFreqNo3 = FifthFreqNo3 + 1;
                        }
                        else
                        {
                            ThirdFreq5 = "";
                            ThirdFreqV5 = "";
                            FifthFreqNo3 = FifthFreqNo3 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the fourth member
                        #region FourthMember Frequency
                        if (chk_Full4.Checked)
                        {
                            FourthFreq = "Full";
                            FourthFreqV = "X";
                            FirstFreqNo4 = 1;
                            SeconFreqNo4 = 1;
                            ThirdFreqNo4 = 1;
                            FourthFreqNo4 = 1;
                            FifthFreqNo4 = 1;
                        }
                        else
                        {
                            FourthFreq = "";
                            FourthFreqV = "";
                        }
                        if (chk_First4.Checked)
                        {
                            FourthFreq1 = "| 1 |";
                            FourthFreqV1 = "X";
                            FirstFreqNo4 = FirstFreqNo4 + 1;
                        }
                        else
                        {
                            FourthFreq1 = "";
                            FourthFreqV1 = "";
                            FirstFreqNo4 = FirstFreqNo4 + 0;
                        }
                        if (chk_Second4.Checked)
                        {
                            FourthFreq2 = "| 2 |";
                            FourthFreqV2 = "X";
                            SeconFreqNo4 = SeconFreqNo4 + 1;
                        }
                        else
                        {
                            FourthFreq2 = "";
                            FourthFreqV2 = "";
                            SeconFreqNo4 = SeconFreqNo4 + 0;
                        }
                        if (chk_Third4.Checked)
                        {
                            FourthFreq3 = "| 3 |";
                            FourthFreqV3 = "X";
                            ThirdFreqNo4 = ThirdFreqNo4 + 1;
                        }
                        else
                        {
                            FourthFreq3 = "";
                            FourthFreqV3 = "";
                            ThirdFreqNo4 = ThirdFreqNo4 + 0;
                        }
                        if (chk_Fourth4.Checked)
                        {
                            FourthFreq4 = "| 4 |";
                            FourthFreqV4 = "X";
                            FourthFreqNo4 = FourthFreqNo4 + 1;
                        }
                        else
                        {
                            FourthFreq4 = "";
                            FourthFreqV4 = "";
                            FourthFreqNo4 = FourthFreqNo4 + 0;
                        }
                        if (chk_Fifth4.Checked)
                        {
                            FourthFreq5 = "| 5 |";
                            FourthFreqV5 = "X";
                            FifthFreqNo4 = FifthFreqNo4 + 1;
                        }
                        else
                        {
                            FourthFreq5 = "";
                            FourthFreqV5 = "";
                            FifthFreqNo4 = FifthFreqNo4 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the fifth member
                        #region FifthMember Frequency
                        if (chk_Full5.Checked)
                        {
                            FifthFreq = "Full";
                            FifthFreqV = "X";
                            FirstFreqNo5 = 1;
                            SeconFreqNo5 = 1;
                            ThirdFreqNo5 = 1;
                            FourthFreqNo5 = 1;
                            FifthFreqNo5 = 1;
                        }
                        else
                        {
                            FifthFreq = "";
                            FifthFreqV = "";
                        }
                        if (chk_First5.Checked)
                        {
                            FifthFreq1 = "| 1 |";
                            FifthFreqV1 = "X";
                            FirstFreqNo5 = FirstFreqNo5 + 1;
                        }
                        else
                        {
                            FifthFreq1 = "";
                            FifthFreqV1 = "";
                            FirstFreqNo5 = FirstFreqNo5 + 0;
                        }
                        if (chk_Second5.Checked)
                        {
                            FifthFreq2 = "| 2 |";
                            FifthFreqV2 = "X";
                            SeconFreqNo5 = SeconFreqNo5 + 1;
                        }
                        else
                        {
                            FifthFreq2 = "";
                            FifthFreqV2 = "";
                            SeconFreqNo5 = SeconFreqNo5 + 0;
                        }
                        if (chk_Third5.Checked)
                        {
                            FifthFreq3 = "| 3 |";
                            FifthFreqV3 = "X";
                            ThirdFreqNo5 = ThirdFreqNo5 + 1;
                        }
                        else
                        {
                            FifthFreq3 = "";
                            FifthFreqV3 = "";
                            ThirdFreqNo5 = ThirdFreqNo5 + 0;
                        }
                        if (chk_Fourth5.Checked)
                        {
                            FifthFreq4 = "| 4 |";
                            FifthFreqV4 = "X";
                            FourthFreqNo5 = FourthFreqNo5 + 1;
                        }
                        else
                        {
                            FifthFreq4 = "";
                            FifthFreqV4 = "";
                            FourthFreqNo5 = FourthFreqNo5 + 0;
                        }
                        if (chk_Fifth5.Checked)
                        {
                            FifthFreq5 = "| 5 |";
                            FifthFreqV5 = "X";
                            FifthFreqNo5 = FifthFreqNo5 + 1;
                        }
                        else
                        {
                            FifthFreq5 = "";
                            FifthFreqV5 = "";
                            FifthFreqNo5 = FifthFreqNo5 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the sixth member
                        #region SixthMember Frequency
                        if (chk_Full6.Checked)
                        {
                            SixthFreq = "Full";
                            SixthFreqV = "X";
                            FirstFreqNo6 = 1;
                            SeconFreqNo6 = 1;
                            ThirdFreqNo6 = 1;
                            FourthFreqNo6 = 1;
                            FifthFreqNo6 = 1;
                        }
                        else
                        {
                            SixthFreq = "";
                            SixthFreqV = "";
                        }
                        if (chk_First6.Checked)
                        {
                            SixthFreq1 = "| 1 |";
                            SixthFreqV1 = "X";
                            FirstFreqNo6 = FirstFreqNo6 + 1;
                        }
                        else
                        {
                            SixthFreq1 = "";
                            SixthFreqV1 = "";
                            FirstFreqNo6 = FirstFreqNo6 + 0;
                        }
                        if (chk_Second6.Checked)
                        {
                            SixthFreq2 = "| 2 |";
                            SixthFreqV2 = "X";
                            SeconFreqNo6 = SeconFreqNo6 + 1;
                        }
                        else
                        {
                            SixthFreq2 = "";
                            SixthFreqV2 = "";
                            SeconFreqNo6 = SeconFreqNo6 + 0;
                        }
                        if (chk_Third6.Checked)
                        {
                            SixthFreq3 = "| 3 |";
                            SixthFreqV3 = "X";
                            ThirdFreqNo6 = ThirdFreqNo6 + 1;
                        }
                        else
                        {
                            SixthFreq3 = "";
                            SixthFreqV3 = "";
                            ThirdFreqNo6 = ThirdFreqNo6 + 0;
                        }
                        if (chk_Fourth6.Checked)
                        {
                            SixthFreq4 = "| 4 |";
                            SixthFreqV4 = "X";
                            FourthFreqNo6 = FourthFreqNo6 + 1;
                        }
                        else
                        {
                            SixthFreq4 = "";
                            SixthFreqV4 = "";
                            FourthFreqNo6 = FourthFreqNo6 + 0;
                        }
                        if (chk_Fifth6.Checked)
                        {
                            SixthFreq5 = "| 5 |";
                            SixthFreqV5 = "X";
                            FifthFreqNo6 = FifthFreqNo6 + 1;
                        }
                        else
                        {
                            SixthFreq5 = "";
                            SixthFreqV5 = "";
                            FifthFreqNo6 = FifthFreqNo6 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the seventh member
                        #region SeventhMember Frequency
                        if (chk_Full7.Checked)
                        {
                            SeventhFreq = "Full";
                            SeventhFreqV = "X";
                            FirstFreqNo7 = 1;
                            SeconFreqNo7 = 1;
                            ThirdFreqNo7 = 1;
                            FourthFreqNo7 = 1;
                            FifthFreqNo7 = 1;
                        }
                        else
                        {
                            SeventhFreq = "";
                            SeventhFreqV = "";
                        }
                        if (chk_First7.Checked)
                        {
                            SeventhFreq1 = "| 1 |";
                            SeventhFreqV1 = "X";
                            FirstFreqNo7 = FirstFreqNo7 + 1;
                        }
                        else
                        {
                            SeventhFreq1 = "";
                            SeventhFreqV1 = "";
                            FirstFreqNo7 = FirstFreqNo7 + 0;
                        }
                        if (chk_Second7.Checked)
                        {
                            SeventhFreq2 = "| 2 |";
                            SeventhFreqV2 = "X";
                            SeconFreqNo7 = SeconFreqNo7 + 1;
                        }
                        else
                        {
                            SeventhFreq2 = "";
                            SeventhFreqV2 = "";
                            SeconFreqNo7 = SeconFreqNo7 + 0;
                        }
                        if (chk_Third7.Checked)
                        {
                            SeventhFreq3 = "| 3 |";
                            SeventhFreqV3 = "X";
                            ThirdFreqNo7 = ThirdFreqNo7 + 1;
                        }
                        else
                        {
                            SeventhFreq3 = "";
                            SeventhFreqV3 = "";
                            ThirdFreqNo7 = ThirdFreqNo7 + 0;
                        }
                        if (chk_Fourth7.Checked)
                        {
                            SeventhFreq4 = "| 4 |";
                            SeventhFreqV4 = "X";
                            FourthFreqNo7 = FourthFreqNo7 + 1;
                        }
                        else
                        {
                            SeventhFreq4 = "";
                            SeventhFreqV4 = "";
                            FourthFreqNo7 = FourthFreqNo7 + 0;
                        }
                        if (chk_Fifth7.Checked)
                        {
                            SeventhFreq5 = "| 5 |";
                            SeventhFreqV5 = "X";
                            FifthFreqNo7 = FifthFreqNo7 + 1;
                        }
                        else
                        {
                            SeventhFreq5 = "";
                            SeventhFreqV5 = "";
                            FifthFreqNo7 = FifthFreqNo7 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the eight member
                        #region EightMember Frequency
                        if (chk_Full8.Checked)
                        {
                            EightFreq = "Full";
                            EightFreqV = "X";
                            FirstFreqNo8 = 1;
                            SeconFreqNo8 = 1;
                            ThirdFreqNo8 = 1;
                            FourthFreqNo8 = 1;
                            FifthFreqNo8 = 1;
                        }
                        else
                        {
                            EightFreq = "";
                            EightFreqV = "";
                        }
                        if (chk_First8.Checked)
                        {
                            EightFreq1 = "| 1 |";
                            EightFreqV1 = "X";
                            FirstFreqNo8 = FirstFreqNo8 + 1;
                        }
                        else
                        {
                            EightFreq1 = "";
                            EightFreqV1 = "";
                            FirstFreqNo8 = FirstFreqNo8 + 0;
                        }
                        if (chk_Second8.Checked)
                        {
                            EightFreq2 = "| 2 |";
                            EightFreqV2 = "X";
                            SeconFreqNo8 = SeconFreqNo8 + 1;
                        }
                        else
                        {
                            EightFreq2 = "";
                            EightFreqV2 = "";
                            SeconFreqNo8 = SeconFreqNo8 + 0;
                        }
                        if (chk_Third8.Checked)
                        {
                            EightFreq3 = "| 3 |";
                            EightFreqV3 = "X";
                            ThirdFreqNo8 = ThirdFreqNo8 + 1;
                        }
                        else
                        {
                            EightFreq3 = "";
                            EightFreqV3 = "";
                            ThirdFreqNo8 = ThirdFreqNo8 + 0;
                        }
                        if (chk_Fourth8.Checked)
                        {
                            EightFreq4 = "| 4 |";
                            EightFreqV4 = "X";
                            FourthFreqNo8 = FourthFreqNo8 + 1;
                        }
                        else
                        {
                            EightFreq4 = "";
                            EightFreqV4 = "";
                            FourthFreqNo8 = FourthFreqNo8 + 0;
                        }
                        if (chk_Fifth8.Checked)
                        {
                            EightFreq5 = "| 5 |";
                            EightFreqV5 = "X";
                            FifthFreqNo8 = FifthFreqNo8 + 1;
                        }
                        else
                        {
                            EightFreq5 = "";
                            EightFreqV5 = "";
                            FifthFreqNo8 = FifthFreqNo8 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the ninth member
                        #region NinthMember Frequency
                        if (chk_Full9.Checked)
                        {
                            NinthFreq = "Full";
                            NinthFreqV = "X";
                            FirstFreqNo9 = 1;
                            SeconFreqNo9 = 1;
                            ThirdFreqNo9 = 1;
                            FourthFreqNo9 = 1;
                            FifthFreqNo9 = 1;
                        }
                        else
                        {
                            NinthFreq = "";
                            NinthFreqV = "";
                        }
                        if (chk_First9.Checked)
                        {
                            NinthFreq1 = "| 1 |";
                            NinthFreqV1 = "X";
                            FirstFreqNo9 = FirstFreqNo9 + 1;
                        }
                        else
                        {
                            NinthFreq1 = "";
                            NinthFreqV1 = "";
                            FirstFreqNo9 = FirstFreqNo9 + 0;
                        }
                        if (chk_Second9.Checked)
                        {
                            NinthFreq2 = "| 2 |";
                            NinthFreqV2 = "X";
                            SeconFreqNo9 = SeconFreqNo9 + 1;
                        }
                        else
                        {
                            NinthFreq2 = "";
                            NinthFreqV2 = "";
                            SeconFreqNo9 = SeconFreqNo9 + 0;
                        }
                        if (chk_Third9.Checked)
                        {
                            NinthFreq3 = "| 3 |";
                            NinthFreqV3 = "X";
                            ThirdFreqNo9 = ThirdFreqNo9 + 1;
                        }
                        else
                        {
                            NinthFreq3 = "";
                            NinthFreqV3 = "";
                            ThirdFreqNo9 = ThirdFreqNo9 + 0;
                        }
                        if (chk_Fourth9.Checked)
                        {
                            NinthFreq4 = "| 4 |";
                            NinthFreqV4 = "X";
                            FourthFreqNo9 = FourthFreqNo9 + 1;
                        }
                        else
                        {
                            NinthFreq4 = "";
                            NinthFreqV4 = "";
                            FourthFreqNo9 = FourthFreqNo9 + 0;
                        }
                        if (chk_Fifth9.Checked)
                        {
                            NinthFreq5 = "| 5 |";
                            NinthFreqV5 = "X";
                            FifthFreqNo9 = FifthFreqNo9 + 1;
                        }
                        else
                        {
                            NinthFreq5 = "";
                            NinthFreqV5 = "";
                            FifthFreqNo9 = FifthFreqNo9 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the tenth member
                        #region TenthMember Frequency
                        if (chk_Full10.Checked)
                        {
                            TenthFreq = "Full";
                            TenthFreqV = "X";
                            FirstFreqNo10 = 1;
                            SeconFreqNo10 = 1;
                            ThirdFreqNo10 = 1;
                            FourthFreqNo10 = 1;
                            FifthFreqNo10 = 1;
                        }
                        else
                        {
                            TenthFreq = "";
                            TenthFreqV = "";
                        }
                        if (chk_First10.Checked)
                        {
                            TenthFreq1 = "| 1 |";
                            TenthFreqV1 = "X";
                            FirstFreqNo10 = FirstFreqNo10 + 1;
                        }
                        else
                        {
                            TenthFreq1 = "";
                            TenthFreqV1 = "";
                            FirstFreqNo10 = FirstFreqNo10 + 0;
                        }
                        if (chk_Second10.Checked)
                        {
                            TenthFreq2 = "| 2 |";
                            TenthFreqV2 = "X";
                            SeconFreqNo10 = SeconFreqNo10 + 1;
                        }
                        else
                        {
                            TenthFreq2 = "";
                            TenthFreqV2 = "";
                            SeconFreqNo10 = SeconFreqNo10 + 0;
                        }
                        if (chk_Third10.Checked)
                        {
                            TenthFreq3 = "| 3 |";
                            TenthFreqV3 = "X";
                            ThirdFreqNo10 = ThirdFreqNo10 + 1;
                        }
                        else
                        {
                            TenthFreq3 = "";
                            TenthFreqV3 = "";
                            ThirdFreqNo10 = ThirdFreqNo10 + 0;
                        }
                        if (chk_Fourth10.Checked)
                        {
                            TenthFreq4 = "| 4 |";
                            TenthFreqV4 = "X";
                            FourthFreqNo10 = FourthFreqNo10 + 1;
                        }
                        else
                        {
                            TenthFreq4 = "";
                            TenthFreqV4 = "";
                            FourthFreqNo10 = FourthFreqNo10 + 0;
                        }
                        if (chk_Fifth10.Checked)
                        {
                            TenthFreq5 = "| 5 |";
                            TenthFreqV5 = "X";
                            FifthFreqNo10 = FifthFreqNo10 + 1;
                        }
                        else
                        {
                            TenthFreq5 = "";
                            TenthFreqV5 = "";
                            FifthFreqNo10 = FifthFreqNo10 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the eleventh member
                        #region EleventhMember Frequency
                        if (chk_Full11.Checked)
                        {
                            EleventhFreq = "Full";
                            EleventhFreqV = "X";
                            FirstFreqNo11 = 1;
                            SeconFreqNo11 = 1;
                            ThirdFreqNo11 = 1;
                            FourthFreqNo11 = 1;
                            FifthFreqNo11 = 1;
                        }
                        else
                        {
                            EleventhFreq = "";
                            EleventhFreqV = "";
                        }
                        if (chk_First11.Checked)
                        {
                            EleventhFreq1 = "| 1 |";
                            EleventhFreqV1 = "X";
                            FirstFreqNo11 = FirstFreqNo11 + 1;
                        }
                        else
                        {
                            EleventhFreq1 = "";
                            EleventhFreqV1 = "";
                            FirstFreqNo11 = FirstFreqNo11 + 0;
                        }
                        if (chk_Second11.Checked)
                        {
                            EleventhFreq2 = "| 2 |";
                            EleventhFreqV2 = "X";
                            SeconFreqNo11 = SeconFreqNo11 + 1;
                        }
                        else
                        {
                            EleventhFreq2 = "";
                            EleventhFreqV2 = "";
                            SeconFreqNo11 = SeconFreqNo11 + 0;
                        }
                        if (chk_Third11.Checked)
                        {
                            EleventhFreq3 = "| 3 |";
                            EleventhFreqV3 = "X";
                            ThirdFreqNo11 = ThirdFreqNo11 + 1;
                        }
                        else
                        {
                            EleventhFreq3 = "";
                            EleventhFreqV3 = "";
                            ThirdFreqNo11 = ThirdFreqNo11 + 0;
                        }
                        if (chk_Fourth11.Checked)
                        {
                            EleventhFreq4 = "| 4 |";
                            EleventhFreqV4 = "X";
                            FourthFreqNo11 = FourthFreqNo11 + 1;
                        }
                        else
                        {
                            EleventhFreq4 = "";
                            EleventhFreqV4 = "";
                            FourthFreqNo11 = FourthFreqNo11 + 0;
                        }
                        if (chk_Fifth11.Checked)
                        {
                            EleventhFreq5 = "| 5 |";
                            EleventhFreqV5 = "X";
                            FifthFreqNo11 = FifthFreqNo11 + 1;
                        }
                        else
                        {
                            EleventhFreq5 = "";
                            EleventhFreqV5 = "";
                            FifthFreqNo11 = FifthFreqNo11 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the twelfth member
                        #region TwelfthMember Frequency
                        if (chk_Full12.Checked)
                        {
                            TwelfthFreq = "Full";
                            TwelfthFreqV = "X";
                            FirstFreqNo12 = 1;
                            SeconFreqNo12 = 1;
                            ThirdFreqNo12 = 1;
                            FourthFreqNo12 = 1;
                            FifthFreqNo12 = 1;
                        }
                        else
                        {
                            TwelfthFreq = "";
                            TwelfthFreqV = "";
                        }
                        if (chk_First12.Checked)
                        {
                            TwelfthFreq1 = "| 1 |";
                            TwelfthFreqV1 = "X";
                            FirstFreqNo12 = FirstFreqNo12 + 1;
                        }
                        else
                        {
                            TwelfthFreq1 = "";
                            TwelfthFreqV1 = "";
                            FirstFreqNo12 = FirstFreqNo12 + 0;
                        }
                        if (chk_Second12.Checked)
                        {
                            TwelfthFreq2 = "| 2 |";
                            TwelfthFreqV2 = "X";
                            SeconFreqNo12 = SeconFreqNo12 + 1;
                        }
                        else
                        {
                            TwelfthFreq2 = "";
                            TwelfthFreqV2 = "";
                            SeconFreqNo12 = SeconFreqNo12 + 0;
                        }
                        if (chk_Third12.Checked)
                        {
                            TwelfthFreq3 = "| 3 |";
                            TwelfthFreqV3 = "X";
                            ThirdFreqNo12 = ThirdFreqNo12 + 1;
                        }
                        else
                        {
                            TwelfthFreq3 = "";
                            TwelfthFreqV3 = "";
                            ThirdFreqNo12 = ThirdFreqNo12 + 0;
                        }
                        if (chk_Fourth12.Checked)
                        {
                            TwelfthFreq4 = "| 4 |";
                            TwelfthFreqV4 = "X";
                            FourthFreqNo12 = FourthFreqNo12 + 1;
                        }
                        else
                        {
                            TwelfthFreq4 = "";
                            TwelfthFreqV4 = "";
                            FourthFreqNo12 = FourthFreqNo12 + 0;
                        }
                        if (chk_Fifth12.Checked)
                        {
                            TwelfthFreq5 = "| 5 |";
                            TwelfthFreqV5 = "X";
                            FifthFreqNo12 = FifthFreqNo12 + 1;
                        }
                        else
                        {
                            TwelfthFreq5 = "";
                            TwelfthFreqV5 = "";
                            FifthFreqNo12 = FifthFreqNo12 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the first reserve member
                        #region FirstReserveMember Frequency
                        if (chk_FullR1.Checked)
                        {
                            FirstReserveFreq = "Full";
                            FirstReserveFreqV = "X";
                            FirstFreqNo13 = 1;
                            SeconFreqNo13 = 1;
                            ThirdFreqNo13 = 1;
                            FourthFreqNo13 = 1;
                            FifthFreqNo13 = 1;
                        }
                        else
                        {
                            FirstReserveFreq = "";
                            FirstReserveFreqV = "";
                        }
                        if (chk_FirstR1.Checked)
                        {
                            FirstReserveFreq1 = "| 1 |";
                            FirstReserveFreqV1 = "X";
                            FirstFreqNo13 = FirstFreqNo13 + 1;
                        }
                        else
                        {
                            FirstReserveFreq1 = "";
                            FirstReserveFreqV1 = "";
                            FirstFreqNo13 = FirstFreqNo13 + 0;
                        }
                        if (chk_SecondR1.Checked)
                        {
                            FirstReserveFreq2 = "| 2 |";
                            FirstReserveFreqV2 = "X";
                            SeconFreqNo13 = SeconFreqNo13 + 1;
                        }
                        else
                        {
                            FirstReserveFreq2 = "";
                            FirstReserveFreqV2 = "";
                            SeconFreqNo13 = SeconFreqNo13 + 0;
                        }
                        if (chk_ThirdR1.Checked)
                        {
                            FirstReserveFreq3 = "| 3 |";
                            FirstReserveFreqV3 = "X";
                            ThirdFreqNo13 = ThirdFreqNo13 + 1;
                        }
                        else
                        {
                            FirstReserveFreq3 = "";
                            FirstReserveFreqV3 = "";
                            ThirdFreqNo13 = ThirdFreqNo13 + 0;
                        }
                        if (chk_FourthR1.Checked)
                        {
                            FirstReserveFreq4 = "| 4 |";
                            FirstReserveFreqV4 = "X";
                            FourthFreqNo13 = FourthFreqNo13 + 1;
                        }
                        else
                        {
                            FirstReserveFreq4 = "";
                            FirstReserveFreqV4 = "";
                            FourthFreqNo13 = FourthFreqNo13 + 0;
                        }
                        if (chk_FifthR1.Checked)
                        {
                            FirstReserveFreq5 = "| 5 |";
                            FirstReserveFreqV5 = "X";
                            FifthFreqNo13 = FifthFreqNo13 + 1;
                        }
                        else
                        {
                            FirstReserveFreq5 = "";
                            FirstReserveFreqV5 = "";
                            FifthFreqNo13 = FifthFreqNo13 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the second reserve member
                        #region SecondReserveMember Frequency
                        if (chk_FullR2.Checked)
                        {
                            SecondReserveFreq = "Full";
                            SecondReserveFreqV = "X";
                            FirstFreqNo14 = 1;
                            SeconFreqNo14 = 1;
                            ThirdFreqNo14 = 1;
                            FourthFreqNo14 = 1;
                            FifthFreqNo14 = 1;
                        }
                        else
                        {
                            SecondReserveFreq = "";
                            SecondReserveFreqV = "";
                        }
                        if (chk_FirstR2.Checked)
                        {
                            SecondReserveFreq1 = "| 1 |";
                            SecondReserveFreqV1 = "X";
                            FirstFreqNo14 = FirstFreqNo14 + 1;
                        }
                        else
                        {
                            SecondReserveFreq1 = "";
                            SecondReserveFreqV1 = "";
                            FirstFreqNo14 = FirstFreqNo14 + 0;
                        }
                        if (chk_SecondR2.Checked)
                        {
                            SecondReserveFreq2 = "| 2 |";
                            SecondReserveFreqV2 = "X";
                            SeconFreqNo14 = SeconFreqNo14 + 1;
                        }
                        else
                        {
                            SecondReserveFreq2 = "";
                            SecondReserveFreqV2 = "";
                            SeconFreqNo14 = SeconFreqNo14 + 0;
                        }
                        if (chk_ThirdR2.Checked)
                        {
                            SecondReserveFreq3 = "| 3 |";
                            SecondReserveFreqV3 = "X";
                            ThirdFreqNo14 = ThirdFreqNo14 + 1;
                        }
                        else
                        {
                            SecondReserveFreq3 = "";
                            SecondReserveFreqV3 = "";
                            ThirdFreqNo14 = ThirdFreqNo14 + 0;
                        }
                        if (chk_FourthR2.Checked)
                        {
                            SecondReserveFreq4 = "| 4 |";
                            SecondReserveFreqV4 = "X";
                            FourthFreqNo14 = FourthFreqNo14 + 1;
                        }
                        else
                        {
                            SecondReserveFreq4 = "";
                            SecondReserveFreqV4 = "";
                            FourthFreqNo14 = FourthFreqNo14 + 0;
                        }
                        if (chk_FifthR2.Checked)
                        {
                            SecondReserveFreq5 = "| 5 |";
                            SecondReserveFreqV5 = "X";
                            FifthFreqNo14 = FifthFreqNo14 + 1;
                        }
                        else
                        {
                            SecondReserveFreq5 = "";
                            SecondReserveFreqV5 = "";
                            FifthFreqNo14 = FifthFreqNo14 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the third reserve member
                        #region ThirdReserveMember Frequency
                        if (chk_FullR3.Checked)
                        {
                            ThirdReserveFreq = "Full";
                            ThirdReserveFreqV = "X";
                            FirstFreqNo15 = 1;
                            SeconFreqNo15 = 1;
                            ThirdFreqNo15 = 1;
                            FourthFreqNo15 = 1;
                            FifthFreqNo15 = 1;
                        }
                        else
                        {
                            ThirdReserveFreq = "";
                            ThirdReserveFreqV = "";
                        }
                        if (chk_FirstR3.Checked)
                        {
                            ThirdReserveFreq1 = "| 1 |";
                            ThirdReserveFreqV1 = "X";
                            FirstFreqNo15 = FirstFreqNo15 + 1;
                        }
                        else
                        {
                            ThirdReserveFreq1 = "";
                            ThirdReserveFreqV1 = "";
                            FirstFreqNo15 = FirstFreqNo15 + 0;
                        }
                        if (chk_SecondR3.Checked)
                        {
                            ThirdReserveFreq2 = "| 2 |";
                            ThirdReserveFreqV2 = "X";
                            SeconFreqNo15 = SeconFreqNo15 + 1;
                        }
                        else
                        {
                            ThirdReserveFreq2 = "";
                            ThirdReserveFreqV2 = "";
                            SeconFreqNo15 = SeconFreqNo15 + 0;
                        }
                        if (chk_ThirdR3.Checked)
                        {
                            ThirdReserveFreq3 = "| 3 |";
                            ThirdReserveFreqV3 = "X";
                            ThirdFreqNo15 = ThirdFreqNo15 + 1;
                        }
                        else
                        {
                            ThirdReserveFreq3 = "";
                            ThirdReserveFreqV3 = "";
                            ThirdFreqNo15 = ThirdFreqNo15 + 0;
                        }
                        if (chk_FourthR3.Checked)
                        {
                            ThirdReserveFreq4 = "| 4 |";
                            ThirdReserveFreqV4 = "X";
                            FourthFreqNo15 = FourthFreqNo15 + 1;
                        }
                        else
                        {
                            ThirdReserveFreq4 = "";
                            ThirdReserveFreqV4 = "";
                            FourthFreqNo15 = FourthFreqNo15 + 0;
                        }
                        if (chk_FifthR3.Checked)
                        {
                            ThirdReserveFreq5 = "| 5 |";
                            ThirdReserveFreqV5 = "X";
                            FifthFreqNo15 = FifthFreqNo15 + 1;
                        }
                        else
                        {
                            ThirdReserveFreq5 = "";
                            ThirdReserveFreqV5 = "";
                            FifthFreqNo15 = FifthFreqNo15 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the fourth reserve member
                        #region FourthReserveMember Frequency
                        if (chk_FullR4.Checked)
                        {
                            FourthReserveFreq = "Full";
                            FourthReserveFreqV = "X";
                            FirstFreqNo16 = 1;
                            SeconFreqNo16 = 1;
                            ThirdFreqNo16 = 1;
                            FourthFreqNo16 = 1;
                            FifthFreqNo16 = 1;
                        }
                        else
                        {
                            FourthReserveFreq = "";
                            FourthReserveFreqV = "";
                        }
                        if (chk_FirstR4.Checked)
                        {
                            FourthReserveFreq1 = "| 1 |";
                            FourthReserveFreqV1 = "X";
                            FirstFreqNo16 = FirstFreqNo16 + 1;
                        }
                        else
                        {
                            FourthReserveFreq1 = "";
                            FourthReserveFreqV1 = "";
                            FirstFreqNo16 = FirstFreqNo16 + 0;
                        }
                        if (chk_SecondR4.Checked)
                        {
                            FourthReserveFreq2 = "| 2 |";
                            FourthReserveFreqV2 = "X";
                            SeconFreqNo16 = SeconFreqNo16 + 1;
                        }
                        else
                        {
                            FourthReserveFreq2 = "";
                            FourthReserveFreqV2 = "";
                            SeconFreqNo16 = SeconFreqNo16 + 0;
                        }
                        if (chk_ThirdR4.Checked)
                        {
                            FourthReserveFreq3 = "| 3 |";
                            FourthReserveFreqV3 = "X";
                            ThirdFreqNo16 = ThirdFreqNo16 + 1;
                        }
                        else
                        {
                            FourthReserveFreq3 = "";
                            FourthReserveFreqV3 = "";
                            ThirdFreqNo16 = ThirdFreqNo16 + 0;
                        }
                        if (chk_FourthR4.Checked)
                        {
                            FourthReserveFreq4 = "| 4 |";
                            FourthReserveFreqV4 = "X";
                            FourthFreqNo16 = FourthFreqNo16 + 1;
                        }
                        else
                        {
                            FourthReserveFreq4 = "";
                            FourthReserveFreqV4 = "";
                            FourthFreqNo16 = FourthFreqNo16 + 0;
                        }
                        if (chk_FifthR4.Checked)
                        {
                            FourthReserveFreq5 = "| 5 |";
                            FourthReserveFreqV5 = "X";
                            FifthFreqNo16 = FifthFreqNo16 + 1;
                        }
                        else
                        {
                            FourthReserveFreq5 = "";
                            FourthReserveFreqV5 = "";
                            FifthFreqNo16 = FifthFreqNo16 + 0;
                        }
                        #endregion
                        //Assigning value of frequency for the fifth reserve member
                        #region FifthReserveMember Frequency
                        if (chk_FullR5.Checked)
                        {
                            FifthReserveFreq = "Full";
                            FifthReserveFreqV = "X";
                            FirstFreqNo17 = 1;
                            SeconFreqNo17 = 1;
                            ThirdFreqNo17 = 1;
                            FourthFreqNo17 = 1;
                            FifthFreqNo17 = 1;
                        }
                        else
                        {
                            FifthReserveFreq = "";
                            FifthReserveFreqV = "";
                        }
                        if (chk_FirstR5.Checked)
                        {
                            FifthReserveFreq1 = "| 1 |";
                            FifthReserveFreqV1 = "X";
                            FirstFreqNo17 = FirstFreqNo17 + 1;
                        }
                        else
                        {
                            FifthReserveFreq1 = "";
                            FifthReserveFreqV1 = "";
                            FirstFreqNo17 = FirstFreqNo17 + 0;
                        }
                        if (chk_SecondR5.Checked)
                        {
                            FifthReserveFreq2 = "| 2 |";
                            FifthReserveFreqV2 = "X";
                            SeconFreqNo17 = SeconFreqNo17 + 1;
                        }
                        else
                        {
                            FifthReserveFreq2 = "";
                            FifthReserveFreqV2 = "";
                            SeconFreqNo17 = SeconFreqNo17 + 0;
                        }
                        if (chk_ThirdR5.Checked)
                        {
                            FifthReserveFreq3 = "| 3 |";
                            FifthReserveFreqV3 = "X";
                            ThirdFreqNo17 = ThirdFreqNo17 + 1;
                        }
                        else
                        {
                            FifthReserveFreq3 = "";
                            FifthReserveFreqV3 = "";
                            ThirdFreqNo17 = ThirdFreqNo17 + 0;
                        }
                        if (chk_FourthR5.Checked)
                        {
                            FifthReserveFreq4 = "| 4 |";
                            FifthReserveFreqV4 = "X";
                            FourthFreqNo17 = FourthFreqNo17 + 1;
                        }
                        else
                        {
                            FifthReserveFreq4 = "";
                            FifthReserveFreqV4 = "";
                            FourthFreqNo17 = FourthFreqNo17 + 0;
                        }
                        if (chk_FifthR5.Checked)
                        {
                            FifthReserveFreq5 = "| 5 |";
                            FifthReserveFreqV5 = "X";
                            FifthFreqNo17 = FifthFreqNo17 + 1;
                        }
                        else
                        {
                            FifthReserveFreq5 = "";
                            FifthReserveFreqV5 = "";
                            FifthFreqNo17 = FifthFreqNo17 + 0;
                        }
                        #endregion

                        string[] list = {FirstMamber+ " - "+ FirstFreq + FirstFreq1 + FirstFreq2 + FirstFreq3 + FirstFreq4 + FirstFreq5,
                                     SecondMember+ " - "+ SecondFreq + SecondFreq1 + SecondFreq2 + SecondFreq3 + SecondFreq4 + SecondFreq5,
                                     ThirdMember+ " - "+ ThirdFreq + ThirdFreq1 + ThirdFreq2 + ThirdFreq3 + ThirdFreq4 + ThirdFreq5,
                                     FourthMember+ " - "+ FourthFreq + FourthFreq1 + FourthFreq2 + FourthFreq3 + FourthFreq4 + FourthFreq5,
                                     FifthMember+ " - "+ FifthFreq + FifthFreq1 + FifthFreq2 + FifthFreq3 + FifthFreq4 + FifthFreq5,
                                     SixthMember+ " - "+ SixthFreq + SixthFreq1 + SixthFreq2 + SixthFreq3 + SixthFreq4 + SixthFreq5,
                                     SeventhMember+ " - "+ SeventhFreq + SeventhFreq1 + SeventhFreq2 + SeventhFreq3 + SeventhFreq4 + SeventhFreq5,
                                     EightMember+ " - "+ EightFreq + EightFreq1 + EightFreq2 + EightFreq3 + EightFreq4 + EightFreq5,
                                     NinthMember+ " - "+ NinthFreq + NinthFreq1 + NinthFreq2 + NinthFreq3 + NinthFreq4 + NinthFreq5,
                                     TenthMember+ " - "+ TenthFreq + TenthFreq1 + TenthFreq2 + TenthFreq3 + TenthFreq4 + TenthFreq5,
                                     EleventhMember+ " - "+ EleventhFreq + EleventhFreq1 + EleventhFreq2 + EleventhFreq3 + EleventhFreq4 + EleventhFreq5,
                                     TwelfthMember+ " - "+ TwelfthFreq + TwelfthFreq1 + TwelfthFreq2 + TwelfthFreq3 + TwelfthFreq4 + TwelfthFreq5,
                                     "Reserves:",
                                     FirstReserve+ " - "+ FirstReserveFreq + FirstReserveFreq1 + FirstReserveFreq2 + FirstReserveFreq3 + FirstReserveFreq4 + FirstReserveFreq5,
                                     SecondReserve+ " - "+ SecondReserveFreq + SecondReserveFreq1 + SecondReserveFreq2 + SecondReserveFreq3 + SecondReserveFreq4 + SecondReserveFreq5,
                                     ThirdReserve+ " - "+ ThirdReserveFreq + ThirdReserveFreq1 + ThirdReserveFreq2 + ThirdReserveFreq3 + ThirdReserveFreq4 + ThirdReserveFreq5,
                                     FourthReserve+ " - "+ FourthReserveFreq + FourthReserveFreq1 + FourthReserveFreq2 + FourthReserveFreq3 + FourthReserveFreq4 + FourthReserveFreq5,
                                     FifthReserve+ " - "+ FifthReserveFreq + FifthReserveFreq1 + FifthReserveFreq2 + FifthReserveFreq3 + FifthReserveFreq4 + FifthReserveFreq5,
                                     "",
                                     "Drop:",
                                     drop1,drop2,drop3,drop4,drop5,drop6, drop7, drop8, drop9};
                        //Variables used for colour change in html format.
                        #region Variable for HTML colours
                        string Member1C = "";
                        string Member2C = "";
                        string Member3C = "";
                        string Member4C = "";
                        string Member5C = "";
                        string Member6C = "";
                        string Member7C = "";
                        string Member8C = "";
                        string Member9C = "";
                        string Member10C = "";
                        string Member11C = "";
                        string Member12C = "";
                        string Member1RC = "";
                        string Member2RC = "";
                        string Member3RC = "";
                        string Member4RC = "";
                        string Member5RC = "";
                        #endregion

                        #region Assign players to the specific class
                        string[] Tanks = { "Sporti", "Sportowiec", "Caer", "Caernach", "Pedro", "Pedroza", "Eurig", "Korim" };
                        string[] Priests = { "Elizabetha", "Ela", "Kasia", "Souris", "Wisia", "Wiska", "Yoshi", "Yoshikoayumi" };
                        string[] Druids = { "Aistana", "Effie", "Elainmoon", "Thunder", "Elfini", "Keri", "Mari", "Maripoza", "Youhei" };
                        string[] Wardens = { "Adrik", "Etze", "Hilarion", "Marcindenmark","Nordia", "Tamire" };
                        string[] Champions = { "Suguru" };
                        string[] Rouges = { "Andrzej", "Andrzejm", "Blusia", "Blumaba", "Ferno", "Ferniacz", "Hennio", "Henio", "Seven", "Seventhsin", "Syla", "Vaxin" };
                        string[] Scouts = { "Firuze", "Mijawian" };
                        string[] Warlocks = { "Hexu", "Hexen", "Hexenmeister" };
                        string[] Mages = { "Deru", "Dersuv", "Hola", "Holiusz", "Keit", "Keithelor", "Chaos", "Lunacy", "Lunek", "Owsiak", "Owsiakus", "Prokto", "Proktolog", "Scari", "Stormmen" };
                        #endregion

                        #region Assigning font color based on a player class
                        //If a user is a tank assign appropriate color.
                        foreach (string x in Tanks)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#ffff80";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#ffff80";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#ffff80";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#ffff80";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#ffff80";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#ffff80";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#ffff80";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#ffff80";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#ffff80";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#ffff80";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#ffff80";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#ffff80";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#ffff80";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#ffff80";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#ffff80";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#ffff80";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#ffff80";
                            }

                        }
                        //If a user is a priest assign appropriate color.
                        foreach (string x in Priests)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#0099ff";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#0099ff";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#0099ff";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#0099ff";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#0099ff";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#0099ff";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#0099ff";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#0099ff";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#0099ff";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#0099ff";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#0099ff";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#0099ff";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#0099ff";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#0099ff";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#0099ff";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#0099ff";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#0099ff";
                            }

                        }
                        //If a user is a warden assign appropriate color.
                        foreach (string x in Wardens)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#dd99ff";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#dd99ff";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#dd99ff";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#dd99ff";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#dd99ff";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#dd99ff";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#dd99ff";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#dd99ff";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#dd99ff";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#dd99ff";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#dd99ff";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#dd99ff";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#dd99ff";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#dd99ff";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#dd99ff";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#dd99ff";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#dd99ff";
                            }

                        }
                        //If a user is a druid assign appropriate color.
                        foreach (string x in Druids)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#70db70";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#70db70";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#70db70";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#70db70";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#70db70";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#70db70";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#70db70";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#70db70";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#70db70";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#70db70";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#70db70";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#70db70";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#70db70";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#70db70";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#70db70";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#70db70";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#70db70";
                            }

                        }
                        //If a user is a champion assign appropriate color.
                        foreach (string x in Champions)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#0000ff";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#0000ff";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#0000ff";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#0000ff";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#0000ff";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#0000ff";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#0000ff";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#0000ff";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#0000ff";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#0000ff";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#0000ff";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#0000ff";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#0000ff";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#0000ff";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#0000ff";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#0000ff";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#0000ff";
                            }

                        }
                        //If a user is a rouge assign appropriate color.
                        foreach (string x in Rouges)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#80aaff";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#80aaff";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#80aaff";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#80aaff";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#80aaff";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#80aaff";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#80aaff";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#80aaff";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#80aaff";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#80aaff";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#80aaff";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#80aaff";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#80aaff";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#80aaff";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#80aaff";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#80aaff";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#80aaff";
                            }

                        }
                        //If a user is a scout assign appropriate color.
                        foreach (string x in Scouts)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#00e600";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#00e600";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#00e600";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#00e600";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#00e600";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#00e600";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#00e600";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#00e600";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#00e600";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#00e600";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#00e600";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#00e600";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#00e600";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#00e600";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#00e600";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#00e600";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#00e600";
                            }

                        }
                        //If a user is a warlock assign appropriate color.
                        foreach (string x in Warlocks)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#8533ff";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#8533ff";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#8533ff";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#8533ff";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#8533ff";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#8533ff";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#8533ff";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#8533ff";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#8533ff";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#8533ff";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#8533ff";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#8533ff";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#8533ff";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#8533ff";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#8533ff";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#8533ff";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#8533ff";
                            }

                        }
                        //If a user is a mage assign appropriate color.
                        foreach (string x in Mages)
                        {
                            if (FirstMamber.Contains(x))
                            {
                                Member1C = "#ff9900";
                            }
                            else if (SecondMember.Contains(x))
                            {
                                Member2C = "#ff9900";
                            }
                            else if (ThirdMember.Contains(x))
                            {
                                Member3C = "#ff9900";
                            }
                            else if (FourthMember.Contains(x))
                            {
                                Member4C = "#ff9900";
                            }
                            else if (FifthMember.Contains(x))
                            {
                                Member5C = "#ff9900";
                            }
                            else if (SixthMember.Contains(x))
                            {
                                Member6C = "#ff9900";
                            }
                            else if (SeventhMember.Contains(x))
                            {
                                Member7C = "#ff9900";
                            }
                            else if (EightMember.Contains(x))
                            {
                                Member8C = "#ff9900";
                            }
                            else if (NinthMember.Contains(x))
                            {
                                Member9C = "#ff9900";
                            }
                            else if (TenthMember.Contains(x))
                            {
                                Member10C = "#ff9900";
                            }
                            else if (EleventhMember.Contains(x))
                            {
                                Member11C = "#ff9900";
                            }
                            else if (TwelfthMember.Contains(x))
                            {
                                Member12C = "#ff9900";
                            }
                            else if (FirstReserve.Contains(x))
                            {
                                Member1RC = "#ff9900";
                            }
                            else if (SecondReserve.Contains(x))
                            {
                                Member2RC = "#ff9900";
                            }
                            else if (ThirdReserve.Contains(x))
                            {
                                Member3RC = "#ff9900";
                            }
                            else if (FourthReserve.Contains(x))
                            {
                                Member4RC = "#ff9900";
                            }
                            else if (FifthReserve.Contains(x))
                            {
                                Member5RC = "#ff9900";
                            }

                        }
                        #endregion

                        int error = 0;

                        if (chk_Drop1.Checked == true)
                        {
                            if (comboBox1.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in First Drop Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox1.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop1.Text == "" || txt_Receiver1.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in First Postion");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop1 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox1.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop1.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura1.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver1.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox1.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop1.Text == "" || txt_Dura1.Text == "" || txt_Receiver1.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in First Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop1 = "<tr><td align='center'><font color='#B389D1'>" + comboBox1.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop1.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura1.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver1.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop2.Checked == true)
                        {
                            if (comboBox2.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Second Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox2.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop2.Text == "" || txt_Receiver2.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Reveiver in Second Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop2 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox2.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop2.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura2.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver2.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox2.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop2.Text == "" || txt_Dura2.Text == "" || txt_Receiver2.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Second Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop2 = "<tr><td align='center'><font color='#B389D1'>" + comboBox2.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop2.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura2.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver2.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop3.Checked == true)
                        {
                            if (comboBox3.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Third Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox3.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop3.Text == "" || txt_Receiver3.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Third Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop3 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox3.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop3.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura3.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver3.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox3.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop3.Text == "" || txt_Dura3.Text == "" || txt_Receiver3.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Third Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop3 = "<tr><td align='center'><font color='#B389D1'>" + comboBox3.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop3.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura3.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver3.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop4.Checked == true)
                        {
                            if (comboBox4.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Fourth Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox4.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop4.Text == "" || txt_Receiver4.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Fourth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop4 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox4.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop4.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura4.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver4.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox4.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop4.Text == "" || txt_Dura4.Text == "" || txt_Receiver4.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Fourth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop4 = "<tr><td align='center'><font color='#B389D1'>" + comboBox4.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop4.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura4.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver4.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop5.Checked == true)
                        {
                            if (comboBox5.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Fifth Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox5.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop5.Text == "" || txt_Receiver5.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Fifth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop5 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox5.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop5.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura5.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver5.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox5.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop5.Text == "" || txt_Dura5.Text == "" || txt_Receiver5.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Fifth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop5 = "<tr><td align='center'><font color='#B389D1'>" + comboBox5.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop5.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura5.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver5.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop6.Checked == true)
                        {
                            if (comboBox6.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Sixth Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox6.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop6.Text == "" || txt_Receiver6.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Sixth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop6 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox6.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop6.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura6.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver6.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox6.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop6.Text == "" || txt_Dura6.Text == "" || txt_Receiver6.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Sixth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop6 = "<tr><td align='center'><font color='#B389D1'>" + comboBox6.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop6.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura6.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver6.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            } 
                        }
                        if (chk_Drop7.Checked == true)
                        {
                            if (comboBox7.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Seventh Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox7.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop7.Text == "" || txt_Receiver7.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Seventh Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop7 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox7.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop7.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura7.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver7.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox7.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop7.Text == "" || txt_Dura7.Text == "" || txt_Receiver7.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Seventh Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop7 = "<tr><td align='center'><font color='#B389D1'>" + comboBox7.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop7.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura7.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver7.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop8.Checked == true)
                        {
                            if (comboBox8.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Eighth Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox8.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop8.Text == "" || txt_Receiver8.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Eighth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop8 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox8.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop8.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura8.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver8.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox8.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop8.Text == "" || txt_Dura8.Text == "" || txt_Receiver8.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Eighth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop8 = "<tr><td align='center'><font color='#B389D1'>" + comboBox8.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop8.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura8.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver8.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        if (chk_Drop9.Checked == true)
                        {
                            if (comboBox9.SelectedItem.ToString() == "Please Select:")
                            {
                                MessageBox.Show("Please select the Drop Type in Ninth Position");
                                error = 1;

                            }
                            else
                            {
                                if (comboBox9.SelectedItem.ToString() == "Stat")
                                {
                                    if (txt_Drop9.Text == "" || txt_Receiver9.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Stat and Receiver in Ninth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        error = 0;
                                        drop9 = "<tr><td align='center'><font color='#89A8CF'>" + comboBox9.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop9.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura9.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver9.Text + "</td></tr>";
                                    }
                                }
                                else if (comboBox9.SelectedItem.ToString() == "Item")
                                {
                                    if (txt_Drop9.Text == "" || txt_Dura9.Text == "" || txt_Receiver9.Text == "")
                                    {
                                        MessageBox.Show("Please enter the Item Name, Item Dura and Receiver in Ninth Position");
                                        error = 1;
                                    }
                                    else
                                    {
                                        drop9 = "<tr><td align='center'><font color='#B389D1'>" + comboBox9.SelectedItem.ToString() + "</td><td align='center'> <font color='#ffffff'>" + txt_Drop9.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Dura9.Text + "</td><td align='center'> <font color='#ffffff'>" + txt_Receiver9.Text + "</td></tr>";
                                        error = 0;
                                    }
                                }
                            }
                        }
                        


                        //Second list which is used to create a HTML format file 
                        string[] list2 = {"<html><body><table style='width:600px' border=1 bgColor='#5c5c8a'>" + "<tr><td align='center'><font color='#ffffff'>Nick</td><td align='center'><font color='#ffffff'>Full</td><td align='center'><font color='#ffffff'>1</td><td align='center'><font color='#ffffff'>2</td><td align='center'><font color='#ffffff'>3</td><td align='center'><font color='#ffffff'>4</td><td align='center'><font color='#ffffff'>5</td></tr>",
                                     "<tr><td align='center'><font color="+Member1C+">"+FirstMamber + "</td><td align='center'> <font color='#00e600'>"+ FirstFreqV +"</td><td align='center'> <font color='#00e600'>"+ FirstFreqV1+"</td><td align='center'> <font color='#00e600'>"+ FirstFreqV2+"</td><td align='center'> <font color='#00e600'>"+ FirstFreqV3+"</td><td align='center'> <font color='#00e600'>"+ FirstFreqV4+"</td><td align='center'><font color='#00e600'>"+ FirstFreqV5+"</td></tr>",
                                     "<tr><td align='center'><font color="+Member2C+">"+SecondMember + "</td><td align='center'><font color='#00e600'>"+ SecondFreqV +"</td><td align='center'><font color='#00e600'>"+ SecondFreqV1 +"</td><td align='center'><font color='#00e600'>"+ SecondFreqV2 +"</td><td align='center'><font color='#00e600'>"+ SecondFreqV3 +"</td><td align='center'><font color='#00e600'>"+ SecondFreqV4 +"</td><td align='center'><font color='#00e600'>"+ SecondFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member3C+">"+ThirdMember + "</td><td align='center'><font color='#00e600'>"+ ThirdFreqV +"</td><td align='center'><font color='#00e600'>"+ ThirdFreqV1 +"</td><td align='center'><font color='#00e600'>"+ ThirdFreqV2 +"</td><td align='center'><font color='#00e600'>"+ ThirdFreqV3 +"</td><td align='center'><font color='#00e600'>"+ ThirdFreqV4 +"</td><td align='center'><font color='#00e600'>"+ ThirdFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member4C+">"+FourthMember + "</td><td align='center'><font color='#00e600'>"+ FourthFreqV +"</td><td align='center'><font color='#00e600'>"+ FourthFreqV1 +"</td><td align='center'><font color='#00e600'>"+ FourthFreqV2 +"</td><td align='center'><font color='#00e600'>"+ FourthFreqV3 +"</td><td align='center'><font color='#00e600'>"+ FourthFreqV4 +"</td><td align='center'><font color='#00e600'>"+ FourthFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member5C+">"+FifthMember + "</td><td align='center'><font color='#00e600'>"+ FifthFreqV +"</td><td align='center'><font color='#00e600'>"+ FifthFreqV1 +"</td><td align='center'><font color='#00e600'>"+ FifthFreqV2 +"</td><td align='center'><font color='#00e600'>"+ FifthFreqV3 +"</td><td align='center'><font color='#00e600'>"+ FifthFreqV4 +"</td><td align='center'><font color='#00e600'>"+ FifthFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member6C+">"+SixthMember + "</td><td align='center'><font color='#00e600'>"+ SixthFreqV +"</td><td align='center'><font color='#00e600'>"+ SixthFreqV1 +"</td><td align='center'><font color='#00e600'>"+ SixthFreqV2 +"</td><td align='center'><font color='#00e600'>"+ SixthFreqV3 +"</td><td align='center'><font color='#00e600'>"+ SixthFreqV4 +"</td><td align='center'><font color='#00e600'>"+ SixthFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member7C+">"+SeventhMember + "</td><td align='center'><font color='#00e600'>"+ SeventhFreqV +"</td><td align='center'><font color='#00e600'>"+ SeventhFreqV1 +"</td><td align='center'><font color='#00e600'>"+ SeventhFreqV2 +"</td><td align='center'><font color='#00e600'>"+ SeventhFreqV3 +"</td><td align='center'><font color='#00e600'>"+ SeventhFreqV4 +"</td><td align='center'><font color='#00e600'>"+ SeventhFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member8C+">"+EightMember + "</td><td align='center'><font color='#00e600'>"+ EightFreqV +"</td><td align='center'><font color='#00e600'>"+ EightFreqV1 +"</td><td align='center'><font color='#00e600'>"+ EightFreqV2 +"</td><td align='center'><font color='#00e600'>"+ EightFreqV3 +"</td><td align='center'><font color='#00e600'>"+ EightFreqV4 +"</td><td align='center'><font color='#00e600'>"+ EightFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member9C+">"+NinthMember + "</td><td align='center'><font color='#00e600'>"+ NinthFreqV +"</td><td align='center'><font color='#00e600'>"+ NinthFreqV1 +"</td><td align='center'><font color='#00e600'>"+ NinthFreqV2 +"</td><td align='center'><font color='#00e600'>"+ NinthFreqV3 +"</td><td align='center'><font color='#00e600'>"+ NinthFreqV4 +"</td><td align='center'><font color='#00e600'>"+ NinthFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member10C+">"+TenthMember + "</td><td align='center'><font color='#00e600'>"+ TenthFreqV +"</td><td align='center'><font color='#00e600'>"+ TenthFreqV1 +"</td><td align='center'><font color='#00e600'>"+ TenthFreqV2 +"</td><td align='center'><font color='#00e600'>"+ TenthFreqV3 +"</td><td align='center'><font color='#00e600'>"+ TenthFreqV4 +"</td><td align='center'><font color='#00e600'>"+ TenthFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member11C+">"+EleventhMember + "</td><td align='center'><font color='#00e600'>"+ EleventhFreqV +"</td><td align='center'><font color='#00e600'>"+ EleventhFreqV1 +"</td><td align='center'><font color='#00e600'>"+ EleventhFreqV2 +"</td><td align='center'><font color='#00e600'>"+ EleventhFreqV3 +"</td><td align='center'><font color='#00e600'>"+ EleventhFreqV4 +"</td><td align='center'><font color='#00e600'>"+ EleventhFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member12C+">"+TwelfthMember + "</td><td align='center'><font color='#00e600'>"+ TwelfthFreqV +"</td><td align='center'><font color='#00e600'>"+ TwelfthFreqV1 +"</td><td align='center'><font color='#00e600'>"+ TwelfthFreqV2 +"</td><td align='center'><font color='#00e600'>"+ TwelfthFreqV3 +"</td><td align='center'><font color='#00e600'>"+ TwelfthFreqV4 +"</td><td align='center'><font color='#00e600'>"+ TwelfthFreqV5 +"</td></tr>",
                                     "<tr></tr><tr><td align='center'><font color='#ffffff'>Reserves</td></tr>",
                                     "<tr><td align='center'><font color="+Member1RC+">"+FirstReserve + "</td><td align='center'><font color='#00e600'>"+ FirstReserveFreqV +"</td><td align='center'><font color='#00e600'>"+ FirstReserveFreqV1 +"</td><td align='center'><font color='#00e600'>"+ FirstReserveFreqV2 +"</td><td align='center'><font color='#00e600'>"+ FirstReserveFreqV3 +"</td><td align='center'><font color='#00e600'>"+ FirstReserveFreqV4 +"</td><td align='center'><font color='#00e600'>"+ FirstReserveFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member2RC+">"+SecondReserve + "</td><td align='center'><font color='#00e600'>"+ SecondReserveFreqV +"</td><td align='center'><font color='#00e600'>"+ SecondReserveFreqV1 +"</td><td align='center'><font color='#00e600'>"+ SecondReserveFreqV2 +"</td><td align='center'><font color='#00e600'>"+ SecondReserveFreqV3 +"</td><td align='center'><font color='#00e600'>"+ SecondReserveFreqV4 +"</td><td align='center'><font color='#00e600'>"+ SecondReserveFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member3RC+">"+ThirdReserve + "</td><td align='center'><font color='#00e600'>"+ ThirdReserveFreqV +"</td><td align='center'><font color='#00e600'>"+ ThirdReserveFreqV1 +"</td><td align='center'><font color='#00e600'>"+ ThirdReserveFreqV2 +"</td><td align='center'><font color='#00e600'>"+ ThirdReserveFreqV3 +"</td><td align='center'><font color='#00e600'>"+ ThirdReserveFreqV4 +"</td><td align='center'><font color='#00e600'>"+ ThirdReserveFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member4RC+">"+FourthReserve + "</td><td align='center'><font color='#00e600'>"+ FourthReserveFreqV +"</td><td align='center'><font color='#00e600'>"+ FourthReserveFreqV1 +"</td><td align='center'><font color='#00e600'>"+ FourthReserveFreqV2 +"</td><td align='center'><font color='#00e600'>"+ FourthReserveFreqV3 +"</td><td align='center'><font color='#00e600'>"+ FourthReserveFreqV4 +"</td><td align='center'><font color='#00e600'>"+ FourthReserveFreqV5 +"</td></tr>",
                                     "<tr><td align='center'><font color="+Member5RC+">"+FifthReserve + "</td><td align='center'><font color='#00e600'>"+ FifthReserveFreqV +"</td><td align='center'><font color='#00e600'>"+ FifthReserveFreqV1 +"</td><td align='center'><font color='#00e600'>"+ FifthReserveFreqV2 +"</td><td align='center'><font color='#00e600'>"+ FifthReserveFreqV3 +"</td><td align='center'><font color='#00e600'>"+ FifthReserveFreqV4 +"</td><td align='center'><font color='#00e600'>"+ FifthReserveFreqV5 +"</td></tr>",
                                     "</table><br /><br />",
                                     "<table style='width:600px' border=1 bgColor='#5c5c8a'>" + "<tr><td align='center'><font color='#ffffff'>Drop Type</td><td align='center'><font color='#ffffff'>Drop Name</td><td align='center'><font color='#ffffff'>Dura</td><td align='center'><font color='#ffffff'>Receiver</td></tr>",
                                     drop1+"<br />",drop2+"<br />",drop3+"<br />",drop4+"<br />",drop5+"<br />",drop6+"<br />", drop7+"<br />", drop8+"<br />", drop9+"</body></html>"};
                        
                        if (error == 0) { 
                            //Checks if a file exists, if it does the system will ask if user wants to update it, otherways the files are saved.
                            if (File.Exists(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\" + date + " - " + RaidTitle + ".txt"))
                            {
                                DialogResult dialofResult = new DialogResult();
                                dialofResult = MessageBox.Show("File " + date + " - " + RaidTitle + ".txt already exists. Do you want to save it anyway?", "Save", MessageBoxButtons.YesNo);
                                if (dialofResult == DialogResult.Yes)
                                {
                                    System.IO.File.WriteAllLines(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\" + date + " - " + RaidTitle + ".txt", list);
                                    System.IO.File.WriteAllLines(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\HTML\" + date + " - " + RaidTitle + ".html", list2);
                                    MessageBox.Show("List updated successfully.");
                                }
                            }
                            else
                            {
                            List<String> newList = new List<String>();
                            newList.Add(FirstMamber);
                            newList.Add(SecondMember);
                            newList.Add(ThirdMember);
                            newList.Add(FourthMember);
                            newList.Add(FifthMember);
                            newList.Add(SixthMember);
                            newList.Add(SeventhMember);
                            newList.Add(EightMember);
                            newList.Add(NinthMember);
                            newList.Add(TenthMember);
                            newList.Add(EleventhMember);
                            newList.Add(TwelfthMember);
                            newList.Add(FirstReserve);
                            newList.Add(SecondReserve);
                            newList.Add(ThirdReserve);
                            newList.Add(FourthReserve);
                            newList.Add(FifthReserve);
                            newList.RemoveAll(str => String.IsNullOrEmpty(str));

                            List<String> FirstBossLists = new List<String>();
                            FirstBossLists.Add(FirstFreqNo1.ToString());
                            FirstBossLists.Add(FirstFreqNo2.ToString());
                            FirstBossLists.Add(FirstFreqNo3.ToString());
                            FirstBossLists.Add(FirstFreqNo4.ToString());
                            FirstBossLists.Add(FirstFreqNo5.ToString());
                            FirstBossLists.Add(FirstFreqNo6.ToString());
                            FirstBossLists.Add(FirstFreqNo7.ToString());
                            FirstBossLists.Add(FirstFreqNo8.ToString());
                            FirstBossLists.Add(FirstFreqNo9.ToString());
                            FirstBossLists.Add(FirstFreqNo10.ToString());
                            FirstBossLists.Add(FirstFreqNo11.ToString());
                            FirstBossLists.Add(FirstFreqNo12.ToString());
                            FirstBossLists.Add(FirstFreqNo13.ToString());
                            FirstBossLists.Add(FirstFreqNo14.ToString());
                            FirstBossLists.Add(FirstFreqNo15.ToString());
                            FirstBossLists.Add(FirstFreqNo16.ToString());
                            FirstBossLists.Add(FirstFreqNo17.ToString());
                            FirstBossLists = FirstBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

                            List<String> SecondBossLists = new List<String>();
                            SecondBossLists.Add(SeconFreqNo1.ToString());
                            SecondBossLists.Add(SeconFreqNo2.ToString());
                            SecondBossLists.Add(SeconFreqNo3.ToString());
                            SecondBossLists.Add(SeconFreqNo4.ToString());
                            SecondBossLists.Add(SeconFreqNo5.ToString());
                            SecondBossLists.Add(SeconFreqNo6.ToString());
                            SecondBossLists.Add(SeconFreqNo7.ToString());
                            SecondBossLists.Add(SeconFreqNo8.ToString());
                            SecondBossLists.Add(SeconFreqNo9.ToString());
                            SecondBossLists.Add(SeconFreqNo10.ToString());
                            SecondBossLists.Add(SeconFreqNo11.ToString());
                            SecondBossLists.Add(SeconFreqNo12.ToString());
                            SecondBossLists.Add(SeconFreqNo13.ToString());
                            SecondBossLists.Add(SeconFreqNo14.ToString());
                            SecondBossLists.Add(SeconFreqNo15.ToString());
                            SecondBossLists.Add(SeconFreqNo16.ToString());
                            SecondBossLists.Add(SeconFreqNo17.ToString());
                            SecondBossLists = SecondBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

                            List<String> ThirdBossLists = new List<String>();
                            ThirdBossLists.Add(ThirdFreqNo1.ToString());
                            ThirdBossLists.Add(ThirdFreqNo2.ToString());
                            ThirdBossLists.Add(ThirdFreqNo3.ToString());
                            ThirdBossLists.Add(ThirdFreqNo4.ToString());
                            ThirdBossLists.Add(ThirdFreqNo5.ToString());
                            ThirdBossLists.Add(ThirdFreqNo6.ToString());
                            ThirdBossLists.Add(ThirdFreqNo7.ToString());
                            ThirdBossLists.Add(ThirdFreqNo8.ToString());
                            ThirdBossLists.Add(ThirdFreqNo9.ToString());
                            ThirdBossLists.Add(ThirdFreqNo10.ToString());
                            ThirdBossLists.Add(ThirdFreqNo11.ToString());
                            ThirdBossLists.Add(ThirdFreqNo12.ToString());
                            ThirdBossLists.Add(ThirdFreqNo13.ToString());
                            ThirdBossLists.Add(ThirdFreqNo14.ToString());
                            ThirdBossLists.Add(ThirdFreqNo15.ToString());
                            ThirdBossLists.Add(ThirdFreqNo16.ToString());
                            ThirdBossLists.Add(ThirdFreqNo17.ToString());
                            ThirdBossLists = ThirdBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

                            List<String> FourthBossLists = new List<String>();
                            FourthBossLists.Add(FourthFreqNo1.ToString());
                            FourthBossLists.Add(FourthFreqNo2.ToString());
                            FourthBossLists.Add(FourthFreqNo3.ToString());
                            FourthBossLists.Add(FourthFreqNo4.ToString());
                            FourthBossLists.Add(FourthFreqNo5.ToString());
                            FourthBossLists.Add(FourthFreqNo6.ToString());
                            FourthBossLists.Add(FourthFreqNo7.ToString());
                            FourthBossLists.Add(FourthFreqNo8.ToString());
                            FourthBossLists.Add(FourthFreqNo9.ToString());
                            FourthBossLists.Add(FourthFreqNo10.ToString());
                            FourthBossLists.Add(FourthFreqNo11.ToString());
                            FourthBossLists.Add(FourthFreqNo12.ToString());
                            FourthBossLists.Add(FourthFreqNo13.ToString());
                            FourthBossLists.Add(FourthFreqNo14.ToString());
                            FourthBossLists.Add(FourthFreqNo15.ToString());
                            FourthBossLists.Add(FourthFreqNo16.ToString());
                            FourthBossLists.Add(FourthFreqNo17.ToString());
                            FourthBossLists = FourthBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();

                            List<String> FifthBossLists = new List<String>();
                            FifthBossLists.Add(FifthFreqNo1.ToString());
                            FifthBossLists.Add(FifthFreqNo2.ToString());
                            FifthBossLists.Add(FifthFreqNo3.ToString());
                            FifthBossLists.Add(FifthFreqNo4.ToString());
                            FifthBossLists.Add(FifthFreqNo5.ToString());
                            FifthBossLists.Add(FifthFreqNo6.ToString());
                            FifthBossLists.Add(FifthFreqNo7.ToString());
                            FifthBossLists.Add(FifthFreqNo8.ToString());
                            FifthBossLists.Add(FifthFreqNo9.ToString());
                            FifthBossLists.Add(FifthFreqNo10.ToString());
                            FifthBossLists.Add(FifthFreqNo11.ToString());
                            FifthBossLists.Add(FifthFreqNo12.ToString());
                            FifthBossLists.Add(FifthFreqNo13.ToString());
                            FifthBossLists.Add(FifthFreqNo14.ToString());
                            FifthBossLists.Add(FifthFreqNo15.ToString());
                            FifthBossLists.Add(FifthFreqNo16.ToString());
                            FifthBossLists.Add(FifthFreqNo17.ToString());
                            FifthBossLists = FifthBossLists.Where(s1 => !string.IsNullOrWhiteSpace(s1)).ToList();
                            NpgsqlConnection cn= new NpgsqlConnection(ConfigurationManager.ConnectionStrings["connA"].ConnectionString);
                            for (var i = 0; i < newList.Count; i++)
                            {
                                
                                if (FirstBossLists[i].ToString() == "1")
                                {
                                    cn.Open();
                                    string queryStr = "Select \"First Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + newList[i] + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_FirstBoss = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"First Boss\" = " + temp + " Where \"Nickname\" ='" + newList[i] + "' ");
                                    update_FirstBoss.Connection = cn;
                                    update_FirstBoss.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (SecondBossLists[i].ToString() == "1")
                                {
                                    cn.Open();
                                    string queryStr2 = "Select \"Second Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + newList[i] + "'";
                                    NpgsqlCommand checkSecongBoss = new NpgsqlCommand(queryStr2, cn);
                                    int temp2 = Convert.ToInt32(checkSecongBoss.ExecuteScalar().ToString());
                                    temp2 = temp2 + 1;
                                    NpgsqlCommand update_SecondBoss = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Second Boss\" = " + temp2 + " Where \"Nickname\" ='" + newList[i] + "' ");
                                    update_SecondBoss.Connection = cn;
                                    update_SecondBoss.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (ThirdBossLists[i].ToString() == "1")
                                {
                                    cn.Open();
                                    string queryStr3 = "Select \"Third Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + newList[i] + "'";
                                    NpgsqlCommand checkThirdBoss = new NpgsqlCommand(queryStr3, cn);
                                    int temp3 = Convert.ToInt32(checkThirdBoss.ExecuteScalar().ToString());
                                    temp3 = temp3 + 1;
                                    NpgsqlCommand update_thirdBoss = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Third Boss\" = " + temp3 + " Where \"Nickname\" ='" + newList[i] + "' ");
                                    update_thirdBoss.Connection = cn;
                                    update_thirdBoss.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (FourthBossLists[i].ToString() == "1")
                                {
                                    cn.Open();
                                    string queryStr4 = "Select \"Fourth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + newList[i] + "'";
                                    NpgsqlCommand checkFourthBoss = new NpgsqlCommand(queryStr4, cn);
                                    int temp4 = Convert.ToInt32(checkFourthBoss.ExecuteScalar().ToString());
                                    temp4 = temp4 + 1;
                                    NpgsqlCommand update_FourthBoss = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Fourth Boss\" = " + temp4 + " Where \"Nickname\" ='" + newList[i] + "' ");
                                    update_FourthBoss.Connection = cn;
                                    update_FourthBoss.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (FifthBossLists[i].ToString() == "1")
                                {
                                    cn.Open();
                                    string queryStr5 = "Select \"Fifth Boss\" from  public.\"IBP\" Where \"Nickname\" = '" + newList[i] + "'";
                                    NpgsqlCommand checkFifthBoss = new NpgsqlCommand(queryStr5, cn);
                                    int temp5 = Convert.ToInt32(checkFifthBoss.ExecuteScalar().ToString());
                                    temp5 = temp5 + 1;
                                    NpgsqlCommand update_FifthBoss = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"Fifth Boss\" = " + temp5 + " Where \"Nickname\" ='" + newList[i] + "' ");
                                    update_FifthBoss.Connection = cn;
                                    update_FifthBoss.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            string DropType1; string DropType2; string DropType3; string DropType4; string DropType5; string DropType6; string DropType7; string DropType8; string DropType9;
                            string DropItem1; string DropItem2; string DropItem3; string DropItem4; string DropItem5; string DropItem6; string DropItem7; string DropItem8; string DropItem9;
                            string ItemReceiver1; string ItemReceiver2; string ItemReceiver3; string ItemReceiver4; string ItemReceiver5; string ItemReceiver6; string ItemReceiver7; string ItemReceiver8; string ItemReceiver9;
                            if (chk_Drop1.Checked == true)
                            {
                                if (comboBox1.SelectedItem.ToString() == "Stat")
                                {
                                    DropType1 = "Stat";
                                    DropItem1 = txt_Drop1.Text;
                                    ItemReceiver1 = txt_Receiver1.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType1+ "', '" + DropItem1 + "','" + ItemReceiver1 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();

                                    
                                    string queryStr = "Select \""+ DropItem1 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver1 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \""+ DropItem1 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver1 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox1.SelectedItem.ToString() == "Item")
                                {
                                    DropType1 = "Item";
                                    DropItem1 = txt_Drop1.Text + " " + txt_Dura1.Text;
                                    ItemReceiver1 = txt_Receiver1.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType1 + "', '" + DropItem1 + "','" + ItemReceiver1 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop2.Checked == true)
                            {
                                if (comboBox2.SelectedItem.ToString() == "Stat")
                                {
                                    DropType2 = "Stat";
                                    DropItem2 = txt_Drop2.Text;
                                    ItemReceiver2 = txt_Receiver2.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType2 + "', '" + DropItem2 + "','" + ItemReceiver2 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();

                                    string queryStr = "Select \"" + DropItem2 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver2 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem2 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver2 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox2.SelectedItem.ToString() == "Item")
                                {
                                    DropType2 = "Item";
                                    DropItem2 = txt_Drop2.Text + " " + txt_Dura2.Text;
                                    ItemReceiver2 = txt_Receiver2.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType2 + "', '" + DropItem2 + "','" + ItemReceiver2 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop3.Checked == true)
                            {
                                if (comboBox3.SelectedItem.ToString() == "Stat")
                                {
                                    DropType3 = "Stat";
                                    DropItem3 = txt_Drop3.Text;
                                    ItemReceiver3 = txt_Receiver3.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType3 + "', '" + DropItem3 + "','" + ItemReceiver3 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem3 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver3 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem3 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver3 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox3.SelectedItem.ToString() == "Item")
                                {
                                    DropType3 = "Item";
                                    DropItem3 = txt_Drop3.Text + " " + txt_Dura3.Text;
                                    ItemReceiver3 = txt_Receiver3.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType3 + "', '" + DropItem3 + "','" + ItemReceiver3 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop4.Checked == true)
                            {
                                if (comboBox4.SelectedItem.ToString() == "Stat")
                                {
                                    DropType4 = "Stat";
                                    DropItem4 = txt_Drop4.Text;
                                    ItemReceiver4 = txt_Receiver4.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType4 + "', '" + DropItem4 + "','" + ItemReceiver4 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem4 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver4 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem4 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver4 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox4.SelectedItem.ToString() == "Item")
                                {
                                    DropType4 = "Item";
                                    DropItem4 = txt_Drop4.Text + " " + txt_Dura4.Text;
                                    ItemReceiver4 = txt_Receiver4.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType4 + "', '" + DropItem4 + "','" + ItemReceiver4 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop5.Checked == true)
                            {
                                if (comboBox5.SelectedItem.ToString() == "Stat")
                                {
                                    DropType5 = "Stat";
                                    DropItem5 = txt_Drop5.Text;
                                    ItemReceiver5 = txt_Receiver5.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType5 + "', '" + DropItem5 + "','" + ItemReceiver5 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem5 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver5 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem5 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver5 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox5.SelectedItem.ToString() == "Item")
                                {
                                    DropType5 = "Item";
                                    DropItem5 = txt_Drop5.Text + " " + txt_Dura5.Text;
                                    ItemReceiver5 = txt_Receiver5.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType5 + "', '" + DropItem5 + "','" + ItemReceiver5 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop6.Checked == true)
                            {
                                if (comboBox6.SelectedItem.ToString() == "Stat")
                                {
                                    DropType6 = "Stat";
                                    DropItem6 = txt_Drop6.Text;
                                    ItemReceiver6 = txt_Receiver6.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType6 + "', '" + DropItem6 + "','" + ItemReceiver6 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem6 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver6 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem6 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver6 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox6.SelectedItem.ToString() == "Item")
                                {
                                    DropType6 = "Item";
                                    DropItem6 = txt_Drop6.Text + " " + txt_Dura6.Text;
                                    ItemReceiver6 = txt_Receiver6.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType6 + "', '" + DropItem6 + "','" + ItemReceiver6 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop7.Checked == true)
                            {
                                if (comboBox7.SelectedItem.ToString() == "Stat")
                                {
                                    DropType7 = "Stat";
                                    DropItem7 = txt_Drop7.Text;
                                    ItemReceiver7 = txt_Receiver7.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType7 + "', '" + DropItem7 + "','" + ItemReceiver7 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem7 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver7 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem7 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver7 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox7.SelectedItem.ToString() == "Item")
                                {
                                    DropType7 = "Item";
                                    DropItem7 = txt_Drop7.Text + " " + txt_Dura7.Text;
                                    ItemReceiver7 = txt_Receiver7.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType7 + "', '" + DropItem7 + "','" + ItemReceiver7 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop8.Checked == true)
                            {
                                if (comboBox8.SelectedItem.ToString() == "Stat")
                                {
                                    DropType8 = "Stat";
                                    DropItem8 = txt_Drop8.Text;
                                    ItemReceiver8 = txt_Receiver8.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType8 + "', '" + DropItem8 + "','" + ItemReceiver8 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem8 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver8 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem8 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver8 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox8.SelectedItem.ToString() == "Item")
                                {
                                    DropType8 = "Item";
                                    DropItem8 = txt_Drop8.Text + " " + txt_Dura8.Text;
                                    ItemReceiver8 = txt_Receiver8.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType8 + "', '" + DropItem8 + "','" + ItemReceiver8 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }
                            if (chk_Drop9.Checked == true)
                            {
                                if (comboBox9.SelectedItem.ToString() == "Stat")
                                {
                                    DropType9 = "Stat";
                                    DropItem9 = txt_Drop9.Text;
                                    ItemReceiver9 = txt_Receiver9.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType9 + "', '" + DropItem9 + "','" + ItemReceiver9 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    string queryStr = "Select \"" + DropItem9 + "\" from  public.\"IBP\" Where \"Nickname\" = '" + ItemReceiver9 + "'";
                                    NpgsqlCommand checkFirstBoss = new NpgsqlCommand(queryStr, cn);
                                    int temp = Convert.ToInt32(checkFirstBoss.ExecuteScalar().ToString());
                                    temp = temp + 1;
                                    NpgsqlCommand update_Stat = new NpgsqlCommand("UPDATE public.\"IBP\" SET \"" + DropItem9 + "\" = " + temp + " Where \"Nickname\" ='" + ItemReceiver9 + "' ");
                                    update_Stat.Connection = cn;
                                    update_Stat.ExecuteNonQuery();
                                    cn.Close();


                                }
                                if (comboBox9.SelectedItem.ToString() == "Item")
                                {
                                    DropType9 = "Item";
                                    DropItem9 = txt_Drop9.Text + " " + txt_Dura9.Text;
                                    ItemReceiver9 = txt_Receiver9.Text;
                                    cn.Open();
                                    NpgsqlCommand InsertDrop = new NpgsqlCommand("Insert into public.\"Items\" Values('" + DropType9 + "', '" + DropItem9 + "','" + ItemReceiver9 + "')");
                                    InsertDrop.Connection = cn;
                                    InsertDrop.ExecuteNonQuery();
                                    cn.Close();
                                }
                            }

                            updateCoquinn();
                            updateTotalFreq();
                            update_TotalNoOfStats();
                            UpdateWSP();
                            Calculate_StaHp251_Rank();
                            Calculate_StaWis251_Rank();
                            Calculate_StaPatt251_Rank();
                            Calculate_StrPatt251_Rank();
                            Calculate_DexPatt251_Rank();
                            Calculate_IntMatt251_Rank();
                            Calculate_IntMatt_Rank();

                            System.IO.File.WriteAllLines(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\" + date + " - " + RaidTitle + ".txt", list);
                                System.IO.File.WriteAllLines(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\HTML\" + date + " - " + RaidTitle + ".html", list2);
                                MessageBox.Show("List saved successfully.");
                            }
                        }
                    }
                
            }

        }
        //When checkbox full for player 1 is checked, disable other checkboxes for player 1, else enable the rest of the checkboxes
        private void chk_Full1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full1.Checked)
            {
                chk_First1.Enabled = false;
                chk_Second1.Enabled = false;
                chk_Third1.Enabled = false;
                chk_Fourth1.Enabled = false;
                chk_Fifth1.Enabled = false;

                chk_First1.Checked = false;
                chk_Second1.Checked = false;
                chk_Third1.Checked = false;
                chk_Fourth1.Checked = false;
                chk_Fifth1.Checked = false;

                chk_Full1.ForeColor = Color.Green;
            }
            else
            {
                chk_First1.Enabled = true;
                chk_Second1.Enabled = true;
                chk_Third1.Enabled = true;
                chk_Fourth1.Enabled = true;
                chk_Fifth1.Enabled = true;

                chk_Full1.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 2 is checked, disable other checkboxes for player 2, else enable the rest of the checkboxes
        private void chk_Full2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full2.Checked)
            {
                chk_First2.Enabled = false;
                chk_Second2.Enabled = false;
                chk_Third2.Enabled = false;
                chk_Fourth2.Enabled = false;
                chk_Fifth2.Enabled = false;

                chk_First2.Checked = false;
                chk_Second2.Checked = false;
                chk_Third2.Checked = false;
                chk_Fourth2.Checked = false;
                chk_Fifth2.Checked = false;

                chk_Full2.ForeColor = Color.Green;
            }
            else
            {
                chk_First2.Enabled = true;
                chk_Second2.Enabled = true;
                chk_Third2.Enabled = true;
                chk_Fourth2.Enabled = true;
                chk_Fifth2.Enabled = true;

                chk_Full2.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 3 is checked, disable other checkboxes for player 3, else enable the rest of the checkboxes
        private void chk_Full3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full3.Checked)
            {
                chk_First3.Enabled = false;
                chk_Second3.Enabled = false;
                chk_Third3.Enabled = false;
                chk_Fourth3.Enabled = false;
                chk_Fifth3.Enabled = false;

                chk_First3.Checked = false;
                chk_Second3.Checked = false;
                chk_Third3.Checked = false;
                chk_Fourth3.Checked = false;
                chk_Fifth3.Checked = false;

                chk_Full3.ForeColor = Color.Green;
            }
            else
            {
                chk_First3.Enabled = true;
                chk_Second3.Enabled = true;
                chk_Third3.Enabled = true;
                chk_Fourth3.Enabled = true;
                chk_Fifth3.Enabled = true;

                chk_Full3.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 4 is checked, disable other checkboxes for player 4, else enable the rest of the checkboxes
        private void chk_Full4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full4.Checked)
            {
                chk_First4.Enabled = false;
                chk_Second4.Enabled = false;
                chk_Third4.Enabled = false;
                chk_Fourth4.Enabled = false;
                chk_Fifth4.Enabled = false;

                chk_First4.Checked = false;
                chk_Second4.Checked = false;
                chk_Third4.Checked = false;
                chk_Fourth4.Checked = false;
                chk_Fifth4.Checked = false;

                chk_Full4.ForeColor = Color.Green;
            }
            else
            {
                chk_First4.Enabled = true;
                chk_Second4.Enabled = true;
                chk_Third4.Enabled = true;
                chk_Fourth4.Enabled = true;
                chk_Fifth4.Enabled = true;

                chk_Full4.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 5 is checked, disable other checkboxes for player 5, else enable the rest of the checkboxes
        private void chk_Full5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full5.Checked)
            {
                chk_First5.Enabled = false;
                chk_Second5.Enabled = false;
                chk_Third5.Enabled = false;
                chk_Fourth5.Enabled = false;
                chk_Fifth5.Enabled = false;

                chk_First5.Checked = false;
                chk_Second5.Checked = false;
                chk_Third5.Checked = false;
                chk_Fourth5.Checked = false;
                chk_Fifth5.Checked = false;

                chk_Full5.ForeColor = Color.Green;
            }
            else
            {
                chk_First5.Enabled = true;
                chk_Second5.Enabled = true;
                chk_Third5.Enabled = true;
                chk_Fourth5.Enabled = true;
                chk_Fifth5.Enabled = true;

                chk_Full5.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 6 is checked, disable other checkboxes for player 6, else enable the rest of the checkboxes
        private void chk_Full6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full6.Checked)
            {
                chk_First6.Enabled = false;
                chk_Second6.Enabled = false;
                chk_Third6.Enabled = false;
                chk_Fourth6.Enabled = false;
                chk_Fifth6.Enabled = false;

                chk_First6.Checked = false;
                chk_Second6.Checked = false;
                chk_Third6.Checked = false;
                chk_Fourth6.Checked = false;
                chk_Fifth6.Checked = false;

                chk_Full6.ForeColor = Color.Green;
            }
            else
            {
                chk_First6.Enabled = true;
                chk_Second6.Enabled = true;
                chk_Third6.Enabled = true;
                chk_Fourth6.Enabled = true;
                chk_Fifth6.Enabled = true;

                chk_Full6.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 7 is checked, disable other checkboxes for player 7, else enable the rest of the checkboxes
        private void chk_Full7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full7.Checked)
            {
                chk_First7.Enabled = false;
                chk_Second7.Enabled = false;
                chk_Third7.Enabled = false;
                chk_Fourth7.Enabled = false;
                chk_Fifth7.Enabled = false;

                chk_First7.Checked = false;
                chk_Second7.Checked = false;
                chk_Third7.Checked = false;
                chk_Fourth7.Checked = false;
                chk_Fifth7.Checked = false;

                chk_Full7.ForeColor = Color.Green;
            }
            else
            {
                chk_First7.Enabled = true;
                chk_Second7.Enabled = true;
                chk_Third7.Enabled = true;
                chk_Fourth7.Enabled = true;
                chk_Fifth7.Enabled = true;

                chk_Full7.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 8 is checked, disable other checkboxes for player 8, else enable the rest of the checkboxes
        private void chk_Full8_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full8.Checked)
            {
                chk_First8.Enabled = false;
                chk_Second8.Enabled = false;
                chk_Third8.Enabled = false;
                chk_Fourth8.Enabled = false;
                chk_Fifth8.Enabled = false;

                chk_First8.Checked = false;
                chk_Second8.Checked = false;
                chk_Third8.Checked = false;
                chk_Fourth8.Checked = false;
                chk_Fifth8.Checked = false;

                chk_Full8.ForeColor = Color.Green;
            }
            else
            {
                chk_First8.Enabled = true;
                chk_Second8.Enabled = true;
                chk_Third8.Enabled = true;
                chk_Fourth8.Enabled = true;
                chk_Fifth8.Enabled = true;

                chk_Full8.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 9 is checked, disable other checkboxes for player 9, else enable the rest of the checkboxes
        private void chk_Full9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full9.Checked)
            {
                chk_First9.Enabled = false;
                chk_Second9.Enabled = false;
                chk_Third9.Enabled = false;
                chk_Fourth9.Enabled = false;
                chk_Fifth9.Enabled = false;

                chk_First9.Checked = false;
                chk_Second9.Checked = false;
                chk_Third9.Checked = false;
                chk_Fourth9.Checked = false;
                chk_Fifth9.Checked = false;

                chk_Full9.ForeColor = Color.Green;
            }
            else
            {
                chk_First9.Enabled = true;
                chk_Second9.Enabled = true;
                chk_Third9.Enabled = true;
                chk_Fourth9.Enabled = true;
                chk_Fifth9.Enabled = true;

                chk_Full9.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 10 is checked, disable other checkboxes for player 10, else enable the rest of the checkboxes
        private void chk_Full10_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full10.Checked)
            {
                chk_First10.Enabled = false;
                chk_Second10.Enabled = false;
                chk_Third10.Enabled = false;
                chk_Fourth10.Enabled = false;
                chk_Fifth10.Enabled = false;

                chk_First10.Checked = false;
                chk_Second10.Checked = false;
                chk_Third10.Checked = false;
                chk_Fourth10.Checked = false;
                chk_Fifth10.Checked = false;

                chk_Full10.ForeColor = Color.Green;
            }
            else
            {
                chk_First10.Enabled = true;
                chk_Second10.Enabled = true;
                chk_Third10.Enabled = true;
                chk_Fourth10.Enabled = true;
                chk_Fifth10.Enabled = true;

                chk_Full10.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 11 is checked, disable other checkboxes for player 11, else enable the rest of the checkboxes
        private void chk_Full11_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full11.Checked)
            {
                chk_First11.Enabled = false;
                chk_Second11.Enabled = false;
                chk_Third11.Enabled = false;
                chk_Fourth11.Enabled = false;
                chk_Fifth11.Enabled = false;

                chk_First11.Checked = false;
                chk_Second11.Checked = false;
                chk_Third11.Checked = false;
                chk_Fourth11.Checked = false;
                chk_Fifth11.Checked = false;

                chk_Full11.ForeColor = Color.Green;
            }
            else
            {
                chk_First11.Enabled = true;
                chk_Second11.Enabled = true;
                chk_Third11.Enabled = true;
                chk_Fourth11.Enabled = true;
                chk_Fifth11.Enabled = true;

                chk_Full11.ForeColor = Color.Black;
            }
        }
        //When checkbox full for player 12 is checked, disable other checkboxes for player 12, else enable the rest of the checkboxes
        private void chk_Full12_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Full12.Checked)
            {
                chk_First12.Enabled = false;
                chk_Second12.Enabled = false;
                chk_Third12.Enabled = false;
                chk_Fourth12.Enabled = false;
                chk_Fifth12.Enabled = false;

                chk_First12.Checked = false;
                chk_Second12.Checked = false;
                chk_Third12.Checked = false;
                chk_Fourth12.Checked = false;
                chk_Fifth12.Checked = false;

                chk_Full12.ForeColor = Color.Green;
            }
            else
            {
                chk_First12.Enabled = true;
                chk_Second12.Enabled = true;
                chk_Third12.Enabled = true;
                chk_Fourth12.Enabled = true;
                chk_Fifth12.Enabled = true;

                chk_Full12.ForeColor = Color.Black;
            }
        }
        //When checkbox "Reserves" is check show the reserve panel, else hide it
        private void chk_Reserves_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Reserves.Checked)
            {
                txt_Reserve1.Visible = true;
                txt_Reserve2.Visible = true;
                txt_Reserve3.Visible = true;
                txt_Reserve4.Visible = true;
                txt_Reserve5.Visible = true;

                lbl_R1.Visible = true;
                lbl_R2.Visible = true;
                lbl_R3.Visible = true;
                lbl_R4.Visible = true;
                lbl_R5.Visible = true;

                chk_FullR1.Visible = true;
                chk_FullR2.Visible = true;
                chk_FullR3.Visible = true;
                chk_FullR4.Visible = true;
                chk_FullR5.Visible = true;

                chk_FirstR1.Visible = true;
                chk_FirstR2.Visible = true;
                chk_FirstR3.Visible = true;
                chk_FirstR4.Visible = true;
                chk_FirstR5.Visible = true;

                chk_SecondR1.Visible = true;
                chk_SecondR2.Visible = true;
                chk_SecondR3.Visible = true;
                chk_SecondR4.Visible = true;
                chk_SecondR5.Visible = true;

                chk_ThirdR1.Visible = true;
                chk_ThirdR2.Visible = true;
                chk_ThirdR3.Visible = true;
                chk_ThirdR4.Visible = true;
                chk_ThirdR5.Visible = true;

                chk_FourthR1.Visible = true;
                chk_FourthR2.Visible = true;
                chk_FourthR3.Visible = true;
                chk_FourthR4.Visible = true;
                chk_FourthR5.Visible = true;

                chk_FifthR1.Visible = true;
                chk_FifthR2.Visible = true;
                chk_FifthR3.Visible = true;
                chk_FifthR4.Visible = true;
                chk_FifthR5.Visible = true;
            }
            else
            {
                txt_Reserve1.Visible = false;
                txt_Reserve2.Visible = false;
                txt_Reserve3.Visible = false;
                txt_Reserve4.Visible = false;
                txt_Reserve5.Visible = false;

                lbl_R1.Visible = false;
                lbl_R2.Visible = false;
                lbl_R3.Visible = false;
                lbl_R4.Visible = false;
                lbl_R5.Visible = false;

                chk_FullR1.Visible = false;
                chk_FullR2.Visible = false;
                chk_FullR3.Visible = false;
                chk_FullR4.Visible = false;
                chk_FullR5.Visible = false;

                chk_FirstR1.Visible = false;
                chk_FirstR2.Visible = false;
                chk_FirstR3.Visible = false;
                chk_FirstR4.Visible = false;
                chk_FirstR5.Visible = false;

                chk_SecondR1.Visible = false;
                chk_SecondR2.Visible = false;
                chk_SecondR3.Visible = false;
                chk_SecondR4.Visible = false;
                chk_SecondR5.Visible = false;

                chk_ThirdR1.Visible = false;
                chk_ThirdR2.Visible = false;
                chk_ThirdR3.Visible = false;
                chk_ThirdR4.Visible = false;
                chk_ThirdR5.Visible = false;

                chk_FourthR1.Visible = false;
                chk_FourthR2.Visible = false;
                chk_FourthR3.Visible = false;
                chk_FourthR4.Visible = false;
                chk_FourthR5.Visible = false;

                chk_FifthR1.Visible = false;
                chk_FifthR2.Visible = false;
                chk_FifthR3.Visible = false;
                chk_FifthR4.Visible = false;
                chk_FifthR5.Visible = false;
            }
        }
        //When checkbox full for reserve player 1 is checked, disable other checkboxes for player reserve 1, else enable the rest of the checkboxes
        private void chk_FullR1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FullR1.Checked)
            {
                chk_FirstR1.Enabled = false;
                chk_SecondR1.Enabled = false;
                chk_ThirdR1.Enabled = false;
                chk_FourthR1.Enabled = false;
                chk_FifthR1.Enabled = false;

                chk_FirstR1.Checked = false;
                chk_SecondR1.Checked = false;
                chk_ThirdR1.Checked = false;
                chk_FourthR1.Checked = false;
                chk_FifthR1.Checked = false;

                chk_FullR1.ForeColor = Color.Green;
            }
            else
            {
                chk_FirstR1.Enabled = true;
                chk_SecondR1.Enabled = true;
                chk_ThirdR1.Enabled = true;
                chk_FourthR1.Enabled = true;
                chk_FifthR1.Enabled = true;

                chk_FullR1.ForeColor = Color.Black;
            }
        }
        //When checkbox full for reserve player 2 is checked, disable other checkboxes for player reserve 2, else enable the rest of the checkboxes
        private void chk_FullR2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FullR2.Checked)
            {
                chk_FirstR2.Enabled = false;
                chk_SecondR2.Enabled = false;
                chk_ThirdR2.Enabled = false;
                chk_FourthR2.Enabled = false;
                chk_FifthR2.Enabled = false;

                chk_FirstR2.Checked = false;
                chk_SecondR2.Checked = false;
                chk_ThirdR2.Checked = false;
                chk_FourthR2.Checked = false;
                chk_FifthR2.Checked = false;

                chk_FullR2.ForeColor = Color.Green;
            }
            else
            {
                chk_FirstR2.Enabled = true;
                chk_SecondR2.Enabled = true;
                chk_ThirdR2.Enabled = true;
                chk_FourthR2.Enabled = true;
                chk_FifthR2.Enabled = true;

                chk_FullR2.ForeColor = Color.Black;
            }
        }
        //When checkbox full for reserve player 3 is checked, disable other checkboxes for player reserve 3, else enable the rest of the checkboxes
        private void chk_FullR3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FullR3.Checked)
            {
                chk_FirstR3.Enabled = false;
                chk_SecondR3.Enabled = false;
                chk_ThirdR3.Enabled = false;
                chk_FourthR3.Enabled = false;
                chk_FifthR3.Enabled = false;

                chk_FirstR3.Checked = false;
                chk_SecondR3.Checked = false;
                chk_ThirdR3.Checked = false;
                chk_FourthR3.Checked = false;
                chk_FifthR3.Checked = false;

                chk_FullR3.ForeColor = Color.Green;
            }
            else
            {
                chk_FirstR3.Enabled = true;
                chk_SecondR3.Enabled = true;
                chk_ThirdR3.Enabled = true;
                chk_FourthR3.Enabled = true;
                chk_FifthR3.Enabled = true;

                chk_FullR3.ForeColor = Color.Black;
            }
        }
        //When checkbox full for reserve player 4 is checked, disable other checkboxes for player reserve 4, else enable the rest of the checkboxes
        private void chk_FullR4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FullR4.Checked)
            {
                chk_FirstR4.Enabled = false;
                chk_SecondR4.Enabled = false;
                chk_ThirdR4.Enabled = false;
                chk_FourthR4.Enabled = false;
                chk_FifthR4.Enabled = false;

                chk_FirstR4.Checked = false;
                chk_SecondR4.Checked = false;
                chk_ThirdR4.Checked = false;
                chk_FourthR4.Checked = false;
                chk_FifthR4.Checked = false;

                chk_FullR4.ForeColor = Color.Green;
            }
            else
            {
                chk_FirstR4.Enabled = true;
                chk_SecondR4.Enabled = true;
                chk_ThirdR4.Enabled = true;
                chk_FourthR4.Enabled = true;
                chk_FifthR4.Enabled = true;

                chk_FullR4.ForeColor = Color.Black;
            }
        }
        //When checkbox full for reserve player 5 is checked, disable other checkboxes for player reserve 5, else enable the rest of the checkboxes
        private void chk_FullR5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_FullR5.Checked)
            {
                chk_FirstR5.Enabled = false;
                chk_SecondR5.Enabled = false;
                chk_ThirdR5.Enabled = false;
                chk_FourthR5.Enabled = false;
                chk_FifthR5.Enabled = false;

                chk_FirstR5.Checked = false;
                chk_SecondR5.Checked = false;
                chk_ThirdR5.Checked = false;
                chk_FourthR5.Checked = false;
                chk_FifthR5.Checked = false;

                chk_FullR5.ForeColor = Color.Green;
            }
            else
            {
                chk_FirstR5.Enabled = true;
                chk_SecondR5.Enabled = true;
                chk_ThirdR5.Enabled = true;
                chk_FourthR5.Enabled = true;
                chk_FifthR5.Enabled = true;

                chk_FullR5.ForeColor = Color.Black;
            }
        }

        private void checkListToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string RaidTitle = txt_Title.Text;
            if (!File.Exists(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\" + date + " - " + RaidTitle + ".txt"))
            {
                DialogResult dialofResult = new DialogResult();
                dialofResult = MessageBox.Show("Are you sure you want to delete a list without saving it?", "Save", MessageBoxButtons.YesNo);
                if (dialofResult == DialogResult.No)
                {
                    
                }
                else
                {
                    Action<Control.ControlCollection> func = null;

                    func = (controls) =>
                    {
                        foreach (Control control in controls)
                            if (control is TextBox)
                                (control as TextBox).Clear();


                            else
                                func(control.Controls);
                    };
                    func(Controls);


                    foreach (Control control in this.Controls)
                    {
                        if (control.GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)control).Checked = false;
                        }
                    }
                }
            }
            else
            {
                Action<Control.ControlCollection> func = null;

                func = (controls) =>
                {
                    foreach (Control control in controls)
                        if (control is TextBox)
                            (control as TextBox).Clear();


                        else
                            func(control.Controls);
                };
                func(Controls);


                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)control).Checked = false;
                    }
                }
            }
        }

        private void newRaidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string RaidTitle = txt_Title.Text;
            if (!File.Exists(@"C:\Users\dersu\OneDrive\Documents\IgnisFreq\" + date + " - " + RaidTitle + ".txt"))
            {
                DialogResult dialofResult = new DialogResult();
                dialofResult = MessageBox.Show("Are you sure you want to delete a list without saving it?", "Save", MessageBoxButtons.YesNo);
                if (dialofResult == DialogResult.No)
                {

                }
                else
                {
                    Action<Control.ControlCollection> func = null;

                    func = (controls) =>
                    {
                        foreach (Control control in controls)
                            if (control is TextBox)
                                (control as TextBox).Clear();


                            else
                                func(control.Controls);
                    };
                    func(Controls);


                    foreach (Control control in this.Controls)
                    {
                        if (control.GetType() == typeof(CheckBox))
                        {
                            ((CheckBox)control).Checked = false;
                        }
                    }
                }
            }
            else
            {
                Action<Control.ControlCollection> func = null;

                func = (controls) =>
                {
                    foreach (Control control in controls)
                        if (control is TextBox)
                            (control as TextBox).Clear();


                        else
                            func(control.Controls);
                };
                func(Controls);


                foreach (Control control in this.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        ((CheckBox)control).Checked = false;
                    }
                }
            }
        }

        private void chk_Drop1_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_Drop1.Checked == true)
            {
                comboBox1.Visible = true;
                lbl_DropType.Visible = true;
                chk_Drop2.Visible = true;
                comboBox1.SelectedIndex = 0;

            }
            else
            {
                comboBox1.Visible = false;
                lbl_DropType.Visible = false;

                txt_Drop1.Visible = false;
                txt_Dura1.Visible = false;
                txt_Receiver1.Visible = false;
                lbl_DropName.Visible = false;
                lbl_Dura.Visible = false;
                lbl_Receiver.Visible = false;
                txt_Drop1.Text = "";
                txt_Dura1.Text = "";
                txt_Receiver1.Text = "";

                comboBox1.SelectedIndex = 0;

                chk_Drop2.Visible = false;
                chk_Drop2.Checked = false;
                txt_Drop2.Visible = false;
                txt_Dura2.Visible = false;
                txt_Receiver2.Visible = false;
                comboBox2.SelectedIndex = 0;
                txt_Drop2.Text = "";
                txt_Dura2.Text = "";
                txt_Receiver2.Text = "";

                chk_Drop3.Visible = false;
                chk_Drop3.Checked = false;
                txt_Drop3.Visible = false;
                txt_Dura3.Visible = false;
                txt_Receiver3.Visible = false;
                comboBox3.SelectedIndex = 0;
                txt_Drop3.Text = "";
                txt_Dura3.Text = "";
                txt_Receiver3.Text = "";

                chk_Drop4.Visible = false;
                chk_Drop4.Checked = false;
                txt_Drop4.Visible = false;
                txt_Dura4.Visible = false;
                txt_Receiver4.Visible = false;
                comboBox4.SelectedIndex = 0;
                txt_Drop4.Text = "";
                txt_Dura4.Text = "";
                txt_Receiver4.Text = "";

                chk_Drop5.Visible = false;
                chk_Drop5.Checked = false;
                txt_Drop5.Visible = false;
                txt_Dura5.Visible = false;
                txt_Receiver5.Visible = false;
                comboBox5.SelectedIndex = 0;
                txt_Drop5.Text = "";
                txt_Dura5.Text = "";
                txt_Receiver5.Text = "";

                chk_Drop6.Visible = false;
                chk_Drop6.Checked = false;
                txt_Drop6.Visible = false;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = false;
                comboBox6.SelectedIndex = 0;
                txt_Drop6.Text = "";
                txt_Dura6.Text = "";
                txt_Receiver6.Text = "";

                chk_Drop7.Visible = false;
                chk_Drop7.Checked = false;
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";
            }
        }

        private void chk_Drop2_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop2.Checked == true)
            {
                comboBox2.Visible = true;
                comboBox2.SelectedIndex = 0;

                chk_Drop3.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
                comboBox2.SelectedIndex = 0;
                txt_Drop2.Text = "";
                txt_Dura2.Text = "";
                txt_Receiver2.Text = "";

                chk_Drop3.Visible = false;
                chk_Drop3.Checked = false;
                txt_Drop3.Visible = false;
                txt_Dura3.Visible = false;
                txt_Receiver3.Visible = false;
                comboBox3.SelectedIndex = 0;
                txt_Drop3.Text = "";
                txt_Dura3.Text = "";
                txt_Receiver3.Text = "";

                chk_Drop4.Visible = false;
                chk_Drop4.Checked = false;
                txt_Drop4.Visible = false;
                txt_Dura4.Visible = false;
                txt_Receiver4.Visible = false;
                comboBox4.SelectedIndex = 0;
                txt_Drop4.Text = "";
                txt_Dura4.Text = "";
                txt_Receiver4.Text = "";

                chk_Drop5.Visible = false;
                chk_Drop5.Checked = false;
                txt_Drop5.Visible = false;
                txt_Dura5.Visible = false;
                txt_Receiver5.Visible = false;
                comboBox5.SelectedIndex = 0;
                txt_Drop5.Text = "";
                txt_Dura5.Text = "";
                txt_Receiver5.Text = "";

                chk_Drop6.Visible = false;
                chk_Drop6.Checked = false;
                txt_Drop6.Visible = false;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = false;
                comboBox6.SelectedIndex = 0;
                txt_Drop6.Text = "";
                txt_Dura6.Text = "";
                txt_Receiver6.Text = "";

                chk_Drop7.Visible = false;
                chk_Drop7.Checked = false;
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";

            }
        }

        private void chk_Drop3_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop3.Checked == true)
            {
                comboBox3.Visible = true;
                comboBox3.SelectedIndex = 0;

                chk_Drop4.Visible = true;
            }
            else
            {
                comboBox3.Visible = false;
                comboBox3.SelectedIndex = 0;
                txt_Drop3.Text = "";
                txt_Dura3.Text = "";
                txt_Receiver3.Text = "";

                chk_Drop4.Visible = false;
                chk_Drop4.Checked = false;
                txt_Drop4.Visible = false;
                txt_Dura4.Visible = false;
                txt_Receiver4.Visible = false;
                comboBox4.SelectedIndex = 0;
                txt_Drop4.Text = "";
                txt_Dura4.Text = "";
                txt_Receiver4.Text = "";

                chk_Drop5.Visible = false;
                chk_Drop5.Checked = false;
                txt_Drop5.Visible = false;
                txt_Dura5.Visible = false;
                txt_Receiver5.Visible = false;
                comboBox5.SelectedIndex = 0;
                txt_Drop5.Text = "";
                txt_Dura5.Text = "";
                txt_Receiver5.Text = "";

                chk_Drop6.Visible = false;
                chk_Drop6.Checked = false;
                txt_Drop6.Visible = false;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = false;
                comboBox6.SelectedIndex = 0;
                txt_Drop6.Text = "";
                txt_Dura6.Text = "";
                txt_Receiver6.Text = "";

                chk_Drop7.Visible = false;
                chk_Drop7.Checked = false;
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";

            }
        }

        private void chk_Drop4_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop4.Checked == true)
            {
                comboBox4.Visible = true;
                chk_Drop5.Visible = true;
                comboBox4.SelectedIndex = 0;
            }
            else
            {
                comboBox4.Visible = false;
                comboBox4.SelectedIndex = 0;
                txt_Drop4.Text = "";
                txt_Dura4.Text = "";
                txt_Receiver4.Text = "";

                chk_Drop5.Visible = false;
                chk_Drop5.Checked = false;
                txt_Drop5.Visible = false;
                txt_Dura5.Visible = false;
                txt_Receiver5.Visible = false;
                comboBox5.SelectedIndex = 0;
                txt_Drop5.Text = "";
                txt_Dura5.Text = "";
                txt_Receiver5.Text = "";

                chk_Drop6.Visible = false;
                chk_Drop6.Checked = false;
                txt_Drop6.Visible = false;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = false;
                comboBox6.SelectedIndex = 0;
                txt_Drop6.Text = "";
                txt_Dura6.Text = "";
                txt_Receiver6.Text = "";

                chk_Drop7.Visible = false;
                chk_Drop7.Checked = false;
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";
            }
        }

        private void chk_Drop5_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop5.Checked == true)
            {
                comboBox5.Visible = true;
                chk_Drop6.Visible = true;
                comboBox5.SelectedIndex = 0;
            }
            else
            {
                comboBox5.Visible = false;
                comboBox5.SelectedIndex = 0;
                txt_Drop5.Text = "";
                txt_Dura5.Text = "";
                txt_Receiver5.Text = "";

                chk_Drop6.Visible = false;
                chk_Drop6.Checked = false;
                txt_Drop6.Visible = false;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = false;
                comboBox6.SelectedIndex = 0;
                txt_Drop6.Text = "";
                txt_Dura6.Text = "";
                txt_Receiver6.Text = "";

                chk_Drop7.Visible = false;
                chk_Drop7.Checked = false;
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";

            }
        }

        private void chk_Drop6_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop6.Checked == true)
            {
                comboBox6.Visible = true;
                lbl_DropType.Visible = true;
                chk_Drop7.Visible = true;
                comboBox6.SelectedIndex = 0;
            }
            else
            {
                comboBox6.Visible = false;
                comboBox6.SelectedIndex = 0;
                txt_Drop6.Text = "";
                txt_Dura6.Text = "";
                txt_Receiver6.Text = "";

                chk_Drop7.Visible = false;
                chk_Drop7.Checked = false;
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";
            }
        }

        private void chk_Drop7_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop7.Checked == true)
            {
                comboBox7.Visible = true;
                comboBox7.SelectedIndex = 0;
                chk_Drop8.Visible = true;
            }
            else
            {
                comboBox7.Visible = false;
                comboBox7.SelectedIndex = 0;
                txt_Drop7.Text = "";
                txt_Dura7.Text = "";
                txt_Receiver7.Text = "";

                chk_Drop8.Visible = false;
                chk_Drop8.Checked = false;
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";
            }
        }

        private void chk_Drop8_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop8.Checked == true)
            {
                comboBox8.Visible = true;
                comboBox8.SelectedIndex = 0;
                chk_Drop9.Visible = true;
            }
            else
            {
                comboBox8.Visible = false;
                comboBox8.SelectedIndex = 0;
                txt_Drop8.Text = "";
                txt_Dura8.Text = "";
                txt_Receiver8.Text = "";

                chk_Drop9.Visible = false;
                chk_Drop9.Checked = false;
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";
            }
        }

        private void chk_Drop9_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Drop9.Checked == true)
            {
                comboBox9.Visible = true;
                comboBox9.SelectedIndex = 0;
            }
            else
            {
                comboBox9.Visible = false;
                comboBox9.SelectedIndex = 0;
                txt_Drop9.Text = "";
                txt_Dura9.Text = "";
                txt_Receiver9.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Item")
            {
                txt_Drop1.Visible = true;
                txt_Dura1.Visible = true;
                txt_Receiver1.Visible = true;
                lbl_DropName.Visible = true;
                lbl_Dura.Visible = true;
                lbl_Receiver.Visible = true;

            }
            else if (comboBox1.SelectedItem.ToString() == "Stat")
            {
                txt_Drop1.Visible = true;
                txt_Dura1.Visible = false;
                txt_Receiver1.Visible = true;
                lbl_DropName.Visible = true;
                lbl_Dura.Visible = false;
                lbl_Receiver.Visible = true;
            }
            else
            {
                txt_Drop1.Visible = false;
                txt_Dura1.Visible = false;
                txt_Receiver1.Visible = false;
                lbl_DropName.Visible = false;
                lbl_Dura.Visible = false;
                lbl_Receiver.Visible = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "Item")
            {
                txt_Drop2.Visible = true;
                txt_Dura2.Visible = true;
                txt_Receiver2.Visible = true;
               

            }
            else if (comboBox2.SelectedItem.ToString() == "Stat")
            {
                txt_Drop2.Visible = true;
                txt_Dura2.Visible = false;
                txt_Receiver2.Visible = true;
                
            }
            else
            {
                txt_Drop2.Visible = false;
                txt_Dura2.Visible = false;
                txt_Receiver2.Visible = false;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Item")
            {
                txt_Drop3.Visible = true;
                txt_Dura3.Visible = true;
                txt_Receiver3.Visible = true;
                

            }
            else if (comboBox3.SelectedItem.ToString() == "Stat")
            {
                txt_Drop3.Visible = true;
                txt_Dura3.Visible = false;
                txt_Receiver3.Visible = true;

            }
            else
            {
                txt_Drop3.Visible = false;
                txt_Dura3.Visible = false;
                txt_Receiver3.Visible = false;
                
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem.ToString() == "Item")
            {
                txt_Drop4.Visible = true;
                txt_Dura4.Visible = true;
                txt_Receiver4.Visible = true;


            }
            else if (comboBox4.SelectedItem.ToString() == "Stat")
            {
                txt_Drop4.Visible = true;
                txt_Dura4.Visible = false;
                txt_Receiver4.Visible = true;

            }
            else
            {
                txt_Drop4.Visible = false;
                txt_Dura4.Visible = false;
                txt_Receiver4.Visible = false;

            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString() == "Item")
            {
                txt_Drop5.Visible = true;
                txt_Dura5.Visible = true;
                txt_Receiver5.Visible = true;


            }
            else if (comboBox5.SelectedItem.ToString() == "Stat")
            {
                txt_Drop5.Visible = true;
                txt_Dura5.Visible = false;
                txt_Receiver5.Visible = true;

            }
            else
            {
                txt_Drop5.Visible = false;
                txt_Dura5.Visible = false;
                txt_Receiver5.Visible = false;

            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem.ToString() == "Item")
            {
                txt_Drop6.Visible = true;
                txt_Dura6.Visible = true;
                txt_Receiver6.Visible = true;


            }
            else if (comboBox6.SelectedItem.ToString() == "Stat")
            {
                txt_Drop6.Visible = true;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = true;

            }
            else
            {
                txt_Drop6.Visible = false;
                txt_Dura6.Visible = false;
                txt_Receiver6.Visible = false;

            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem.ToString() == "Item")
            {
                txt_Drop7.Visible = true;
                txt_Dura7.Visible = true;
                txt_Receiver7.Visible = true;


            }
            else if (comboBox7.SelectedItem.ToString() == "Stat")
            {
                txt_Drop7.Visible = true;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = true;

            }
            else
            {
                txt_Drop7.Visible = false;
                txt_Dura7.Visible = false;
                txt_Receiver7.Visible = false;

            }
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedItem.ToString() == "Item")
            {
                txt_Drop8.Visible = true;
                txt_Dura8.Visible = true;
                txt_Receiver8.Visible = true;


            }
            else if (comboBox8.SelectedItem.ToString() == "Stat")
            {
                txt_Drop8.Visible = true;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = true;

            }
            else
            {
                txt_Drop8.Visible = false;
                txt_Dura8.Visible = false;
                txt_Receiver8.Visible = false;

            }
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox9.SelectedItem.ToString() == "Item")
            {
                txt_Drop9.Visible = true;
                txt_Dura9.Visible = true;
                txt_Receiver9.Visible = true;


            }
            else if (comboBox9.SelectedItem.ToString() == "Stat")
            {
                txt_Drop9.Visible = true;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = true;

            }
            else
            {
                txt_Drop9.Visible = false;
                txt_Dura9.Visible = false;
                txt_Receiver9.Visible = false;

            }
        }

      
        private void howItWorksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Ignis Frequency Application" + Environment.NewLine + Environment.NewLine + "This application was developed to help create dungeon lists, which later are used to update database." + Environment.NewLine +
                Environment.NewLine + "How it works" + Environment.NewLine + Environment.NewLine + "On the left side of the screen is the main area, where user is asked to enter the title of the ride (This title is used as a file name" +
                "Once the title is entered, the next thing to do is to enter usernames of people who were present at the dungeon and select the bosses they encountered. If during the dungeon the squad was modified it means that there were more than 12 characters" +
                "present at that time. Therefore to enter additional characters, press the 'Reserve' checkbox and additional fields will be displayed."+ Environment.NewLine + Environment.NewLine + "The next" +
                "step is to enter the drop that was looted from bosses, to do it press 'Drop 1' Checkbox on the left hand side and follow  next steps to fill in all neccessary details. Once all data is entered into the fields" +
                "press 'Submit' button to save the list.");
         }

        private void txt_Dura1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_Dura9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
