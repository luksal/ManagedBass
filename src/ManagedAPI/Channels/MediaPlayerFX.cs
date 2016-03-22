﻿namespace ManagedBass.Fx
{
    /// <summary>
    /// A Reusable Channel which can Load files like a Player including Tempo, Pitch and Reverse options using BassFx.
    /// </summary>
    public class MediaPlayerFX : MediaPlayer
    {
        int TempoHandle;

        #region Reverse
        bool rev = false;

        /// <summary>
        /// Gets or Sets the Media playback direction.
        /// </summary>
        public bool Reverse
        {
            get { return rev; }
            set
            {
                if (Bass.ChannelSetAttribute(Handle, ChannelAttribute.ReverseDirection, value ? -1 : 1))
                {
                    rev = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Pitch
        double pitch = 0;

        /// <summary>
        /// Gets or Sets the Pitch in Semitones (-60 ... 0 ... 60).
        /// </summary>
        public double Pitch
        {
            get { return pitch; }
            set
            {
                if (Bass.ChannelSetAttribute(TempoHandle, ChannelAttribute.Pitch, value))
                {
                    pitch = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Tempo
        double tempo = 0;

        /// <summary>
        /// Gets or Sets the Tempo in Percentage (-95% ... 0 ... 5000%)
        /// </summary>
        public double Tempo
        {
            get { return tempo; }
            set
            {
                if (Bass.ChannelSetAttribute(TempoHandle, ChannelAttribute.Tempo, value))
                {
                    tempo = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
                
        protected override int OnLoad(string FileName)
        {
            int h = Bass.CreateStream(FileName, Flags: BassFlags.Decode);

            if (h == 0)
                return 0;

            h = BassFx.TempoCreate(h, BassFlags.Decode | BassFlags.FxFreeSource);

            if (h == 0)
                return 0;

            TempoHandle = h;

            return BassFx.ReverseCreate(h, 2, BassFlags.FxFreeSource);
        }

        protected override void InitProperties()
        {
            Reverse = rev;

            base.InitProperties();

            Tempo = tempo;
            Pitch = pitch;
        }
    }
}