using SPTLauncher.Components;
using SPTLauncher.Constructors;
using SPTLauncher.Constructors.Enums;

namespace SPTLauncher
{
    public partial class TradersEditor : Form
    {
        public TradersEditor()
        {
            InitializeComponent();
        }

        private void TradersEditor_Load(object sender, EventArgs e)
        {
            foreach (Trader trader in Traders.GetTraders())
                tradersBox.Items.Add(trader);
            if (tradersBox.Items.Count > 0) tradersBox.SelectedIndex = 0;
        }

        private void tradersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tradersBox.SelectedItem != null) PopulateItems((Trader)tradersBox.SelectedItem);
        }

        private void loyaltyBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tradersBox.SelectedItem != null) PopulateLoyaltyItems((LoyaltyLevel)loyaltyBox.SelectedItem);
            groupBox2.Enabled = loyaltyBox.SelectedItem != null;
        }

        public void PopulateItems(Trader trader)
        {
            loyaltyBox.Items.Clear();
            if (currencyBox.Items.Count == 0) foreach (Currency currency in Enum.GetValues(typeof(Currency))) currencyBox.Items.Add(currency);
            currencyBox.SelectedItem = Enum.Parse(typeof(Currency), trader.currency);
            traderID.Text = trader.id;
            refreshTime.Value = trader.refreshTime;
            gridHeight.Value = trader.gridHeight;
            insuranceCheckBox.Checked = trader.insurance;
            minReturnTime.Value = trader.minReturnHour;
            maxReturnTime.Value = trader.maxReturnHour;
            medicCheckBox.Checked = trader.medic;
            unlocked.Checked = trader.unlocked;
            foreach (LoyaltyLevel loyaltyLevel in trader.loyaltyLevels)
                loyaltyBox.Items.Add(loyaltyLevel);
            if (loyaltyBox.Items.Count > 0) loyaltyBox.SelectedIndex = 0;
        }
        static string FormatTimeSpan(TimeSpan timeSpan)
        {
            // Customize the time format as needed
            return string.Format("{0:D2}h {1:D2}m {2:D2}s",
                timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }

        public void PopulateLoyaltyItems(LoyaltyLevel loyaltyLevel)
        {
            buyCoef.Value = loyaltyLevel.buyPriceCoef;
            exchangeCoef.Value = loyaltyLevel.exchangePriceCoef;
            healCoef.Value = loyaltyLevel.healPriceCoef;
            insuranceCoef.Value = loyaltyLevel.insurancePriceCoef;
            repairCoef.Value = loyaltyLevel.repairPriceCoef;
            minLevel.Value = loyaltyLevel.minLevel;
            saleSum.Value = loyaltyLevel.minSalesSum;
            minStanding.Value = (decimal)loyaltyLevel.minStanding;
        }

        private void insuranceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            InsuranceGroup.Enabled = insuranceCheckBox.Checked;
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            PopulateItems((Trader)tradersBox.SelectedItem);
        }

        private void newLoyaltyLevel_Click(object sender, EventArgs e)
        {
            int level = loyaltyBox.Items.Count + 1;
            loyaltyBox.Items.Add(new LoyaltyLevel(level));
        }

        private void minLevel_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().minLevel = (int)minLevel.Value;
        }

        public Trader GetSelectedTrader()
        {
            return (Trader)tradersBox.SelectedItem;
        }

        public LoyaltyLevel GetSelectedLevel()
        {
            return (LoyaltyLevel)loyaltyBox.SelectedItem;
        }

        private void minStanding_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().minStanding = (float)minStanding.Value;
        }

        private void saleSum_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().minSalesSum = (int)saleSum.Value;
        }

        private void buyCoef_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().buyPriceCoef = (int)buyCoef.Value;
        }

        private void healCoef_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().healPriceCoef = (int)healCoef.Value;
        }

        private void repairCoef_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().repairPriceCoef = (int)repairCoef.Value;
        }

        private void exchangeCoef_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().exchangePriceCoef = (int)exchangeCoef.Value;
        }

        private void insuranceCoef_ValueChanged(object sender, EventArgs e)
        {
            GetSelectedLevel().insurancePriceCoef = (int)insuranceCoef.Value;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
