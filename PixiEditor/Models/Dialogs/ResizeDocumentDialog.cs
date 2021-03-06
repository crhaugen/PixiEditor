﻿using PixiEditor.Models.Enums;
using PixiEditor.Views;

namespace PixiEditor.Models.Dialogs
{
    public class ResizeDocumentDialog : CustomDialog
    {
        public bool OpenResizeCanvas { get; set; }
        public AnchorPoint ResizeAnchor { get; set; }

        public int Width
        {
            get => _width;
            set
            {
                if (_width != value)
                {
                    _width = value;
                    RaisePropertyChanged("Width");
                }
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    RaisePropertyChanged("Height");
                }
            }
        }

        private int _height;
        private int _width;

        public ResizeDocumentDialog(int currentWidth, int currentHeight, bool openResizeCanvas = false)
        {
            Width = currentWidth;
            Height = currentHeight;
            OpenResizeCanvas = openResizeCanvas;
        }

        public override bool ShowDialog()
        {
            return OpenResizeCanvas ? ShowResizeCanvasDialog() : ShowResizeDocumentCanvas();
        }

        private bool ShowResizeDocumentCanvas()
        {
            ResizeDocumentPopup popup = new ResizeDocumentPopup
            {
                NewHeight = Height,
                NewWidth = Width
            };

            popup.ShowDialog();
            if (popup.DialogResult == true)
            {
                Width = popup.NewWidth;
                Height = popup.NewHeight;
            }

            return (bool) popup.DialogResult;
        }

        private bool ShowResizeCanvasDialog()
        {
            ResizeCanvasPopup popup = new ResizeCanvasPopup
            {
                NewHeight = Height,
                NewWidth = Width
            };

            popup.ShowDialog();
            if (popup.DialogResult == true)
            {
                Width = popup.NewWidth;
                Height = popup.NewHeight;
                ResizeAnchor = popup.SelectedAnchorPoint;
            }

            return (bool) popup.DialogResult;
        }
    }
}