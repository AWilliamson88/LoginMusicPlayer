using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using WMPLib;

/// <summary>
/// Author: Andrew Williamson
/// 
/// </summary>
namespace JMC_Music_Player.GUI
{
    public partial class MusicPlayerForm : Form
    {
        public MusicPlayerForm()
        {
            InitializeComponent();
        }

        private MusicController mc;
        private Button activeButton;

        #region Opening and Closing
        private void MusicPlayerForm_Load(object sender, EventArgs e)
        {
            mc = new MusicController(MusicPlayer);
            MusicPlayer.settings.autoStart = false;
            LoadSongList();
            SetButtons();
            MusicPlayer.PlayStateChange +=
                new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(
                    MusicPlayer_PlayStateChange
                );
        }

        private void MusicPlayerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSongList();
            MusicPlayer.PlayStateChange -=
                new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(
                    MusicPlayer_PlayStateChange
                );
        }
        #endregion

        // Methods for loading and saving the song list to a csv.
        // Uses a 3rd party library
        #region SongListMethods
        /// /// <summary>
        /// Method to Load the song list from a csv into a linked list.
        /// Uses the 3rd party library CsvHelper.
        /// </summary>
        private void LoadSongList()
        {
            try
            {
                using (var reader = new StreamReader(@"..\..\..\Songs\SongList.csv"))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        mc.ClearSongList();
                        if (csv.Read() == true)
                            csv.ReadHeader();

                        var records = csv.GetRecords<Song>();

                        foreach (var s in records)
                        {
                            mc.Add(s);
                        }
                        DisplayAllSongs();
                    }
                }

            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

        }
        /// <summary>
        /// Opens the file dialog and adds the selected songs to the list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddBtn_Click(object sender, EventArgs e)
        {
            AddSong();
            HighlightCurrentSongInDisplay();
        }
        private void AddSong()
        {
            try
            {
                using (OpenFileDialog openDialog = new OpenFileDialog())
                {
                    if (!Directory.Exists(@"..\..\..\..\..\Music"))
                    {
                        // set initial directory
                        openDialog.InitialDirectory = @"..\..\..\..\..\Music";
                    }
                    // set title
                    openDialog.Title = "Add song to playlist.";
                    // set extention
                    openDialog.Filter = "MP3 files | *.mp3";
                    // multi select
                    openDialog.Multiselect = true;

                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        // list of files
                        foreach (string fileName in openDialog.FileNames)
                        {
                            mc.Add(fileName);
                        }
                        mc.SortList();
                        DisplayAllSongs();
                        SetButtons();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to load songs.", "Loading Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Saves the list of users to a csv file using the 3rd party library CsvHelper.
        /// </summary>
        public void SaveSongList()
        {
            try
            {
                if (!Directory.Exists(@"..\..\..\Songs"))
                {
                    Directory.CreateDirectory(@"..\..\..\Songs");
                }
                if (!File.Exists(@"..\..\..\Songs\SongList.csv"))
                {
                    File.Create(@"..\..\..\Songs\SongList.csv");
                }

                using (var writer = new StreamWriter(@"..\..\..\Songs\SongList.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<Song>();
                    csv.NextRecord();
                    csv.WriteRecords(mc.GetSongList());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        #endregion

        #region FormDisplayMethods
        /// <summary>
        /// Sets which buttons are accessible based on song count and current song.
        /// </summary>
        private void SetButtons()
        {
            if (mc.GetSongList().Count == 0)
            {
                PlayPauseBtn.Enabled = false;
                SearchBtn.Enabled = false;
                SearchTB.Enabled = false;
                StopBtn.Enabled = false;
                NextBtn.Enabled = false;
                PreviousBtn.Enabled = false;
            }
            else if (mc.GetSongList().Count >= 1)
            {
                PlayPauseBtn.Enabled = true;
                SearchBtn.Enabled = true;
                SearchTB.Enabled = true;
            }

            if (mc.CurrentSong() != null)
            {
                NextBtn.Enabled = true;
                PreviousBtn.Enabled = true;
                StopBtn.Enabled = true;
            }

        }

        /// <summary>
        /// Makes either the play button green, the pause button blue, the stop
        /// button red or resets them back to normal based on the music players state.
        /// </summary>
        private void MusicPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            DeactivateButton();

            if (MusicPlayer.playState == WMPPlayState.wmppsPlaying)
            {
                BtnStatePlaying();
            }
            else if (MusicPlayer.playState == WMPPlayState.wmppsPaused)
            {
                BtnStatePaused();
            }
            else if (MusicPlayer.playState == WMPPlayState.wmppsStopped)
            {
                BtnStateStopped();
            }

            if (activeButton != null)
            {
                ActiveBtnStyle();
            }
        }
        private void BtnStatePlaying()
        {
            activeButton = PlayPauseBtn;
            activeButton.Text = "Playing";
            activeButton.BackColor = Color.FromArgb(67, 183, 110);
        }
        private void BtnStatePaused()
        {
            activeButton = PlayPauseBtn;
            activeButton.Text = "Paused";
            activeButton.BackColor = Color.FromArgb(73, 197, 220);
        }
        private void BtnStateStopped()
        {
            activeButton = StopBtn;
            activeButton.Text = "Stopped";
            activeButton.BackColor = Color.FromArgb(223, 15, 0);
        }
        private void ActiveBtnStyle()
        {
            activeButton.Font = new Font("Microsoft Sans Serif", 14F);
            activeButton.ForeColor = Color.White;
        }

        /// <summary>
        /// Method called by the ActivateButton method to reset the active button to 
        /// normal.
        /// </summary>
        private void DeactivateButton()
        {
            if (activeButton != null)
            {
                if (activeButton == PlayPauseBtn)
                    PlayPauseBtn.Text = "Play/Pause";

                StopBtn.Text = "Stop";
                activeButton.BackColor = default;
                activeButton.UseVisualStyleBackColor = true;
                activeButton.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
                activeButton.Font = new Font("Microsoft Sans Serif", 12F);
            }
        }

        /// <summary>
        /// Uses the music players url to get the song title and once found in the list
        /// box it is higlighted.
        /// </summary>
        private void HighlightCurrentSongInDisplay()
        {
            if (mc.CurrentSong() != null)
            {
                // Get the name of the current song from the path in the currentSong node.
                string songName = Path.GetFileNameWithoutExtension(MusicPlayer.URL);
                // Find the song name and select it.
                SongDisplayListBox.SelectedIndex = SongDisplayListBox.FindString(songName);
            }
        }

        /// <summary>
        /// Displays all the songs in the list box.
        /// </summary>
        private void DisplayAllSongs()
        {
            SongDisplayListBox.Items.Clear();
            foreach (Song song in mc.GetSongList())
            {
                SongDisplayListBox.Items.Add(song.Title);
            }
        }

        #endregion

        #region MusicPlayerControls
        private void PlayPauseBtn_Click(object sender, EventArgs e)
        {
            //this.BeginInvoke(new Action(() => mc.PlayPause()));
            mc.PlayPause();

            HighlightCurrentSongInDisplay();
            SetButtons();
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            mc.Stop();
            HighlightCurrentSongInDisplay();
            SetButtons();
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            mc.Next();
            HighlightCurrentSongInDisplay();
            SetButtons();
            mc.PlayPause();
        }

        private void PreviousBtn_Click(object sender, EventArgs e)
        {
            mc.Previous();
            HighlightCurrentSongInDisplay();
            SetButtons();
            mc.PlayPause();
        }
        #endregion

        // Contains searching techniques
        // Methods to start the searching process.
        #region Search
        private void SearchTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Search();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// Custom method to start searching for the song whose title was 
        /// typed into the search box.
        /// </summary>
        private void Search()
        {
            if (!string.IsNullOrEmpty(SearchTB.Text))
            {
                mc.SearchForSong(SearchTB.Text);
                SearchTB.Clear();
                HighlightCurrentSongInDisplay();
            }
        }

        #endregion

    }
}
