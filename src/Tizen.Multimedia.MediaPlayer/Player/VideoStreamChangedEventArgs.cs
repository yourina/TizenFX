/// This File contains VideoStreamEventArgs class
///
/// Copyright 2016 by Samsung Electronics, Inc.,
/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides data for the <see cref="Player.VideoStreamChanged"/> event.
    /// </summary>
    public class VideoStreamChangedEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the VideoStreamChangedEventArgs class.
        /// </summary>
        internal VideoStreamChangedEventArgs(int height, int width, int fps, int bitRate)
        {
            Size = new Size(width, height);
            Fps = fps;
            BitRate = bitRate;
        }

        /// <summary>
        /// Gets the <see cref="Size"/> of new video.
        /// </summary>
        public Size Size { get; }

        /// <summary>
        /// Gets the fps of new video
        /// </summary>
        public int Fps { get; }

        /// <summary>
        /// Gets the bit rate of new video.
        /// </summary>
        public int BitRate { get; }

        public override string ToString()
        {
            return $"Size=({ Size.ToString() }), Fps={ Fps.ToString() }, BitRate={ BitRate.ToString() }";
        }
    }
}
