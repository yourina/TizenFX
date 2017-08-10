/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEventListener
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// This class provides the methods and properties to get information about the posted or updated notification.
    /// </summary>
    public partial class NotificationEventArgs : EventArgs
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        internal IDictionary<string, StyleArgs> Style;
        internal IDictionary<string, Bundle> Extender;
        internal Interop.NotificationEventListener.NotificationSafeHandle Handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationEventArgs"/> class.
        /// </summary>
        public NotificationEventArgs()
        {
            Style = new Dictionary<string, StyleArgs>();
            Extender = new Dictionary<string, Bundle>();
        }

        /// <summary>
        /// Gets the unique id of Notification.
        /// </summary>
        public int UniqueNumber { get; internal set; }

        /// <summary>
        /// Gets the appId of Notification.
        /// </summary>
        public string AppID { get; internal set; }

        /// <summary>
        /// Gets the title of Notification.
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// Gets the content text of Notification.
        /// </summary>
        public string Content { get; internal set; }

        /// <summary>
        /// Gets the icon's path of Notification.
        /// </summary>
        public string Icon { get; internal set; }

        /// <summary>
        /// Gets the sub icon path of Notification.
        /// </summary>
        public string SubIcon { get; internal set; }

        /// <summary>
        /// Gets the Timestamp of notification is visible or not.
        /// </summary>
        public bool IsTimeStampVisible { get; internal set; }

        /// <summary>
        /// Gets TimeStamp of Notification.
        /// </summary>
        /// <remarks>
        /// If IsTimeStampVisible property is set false, this TimeStamp property is meanless.
        /// </remarks>
        public DateTime TimeStamp { get; internal set; }

        /// <summary>
        /// Gets the count which is displayed at the right side of notification.
        /// </summary>
        public int Count { get; internal set; }

        /// <summary>
        /// Gets the Tag of notification.
        /// </summary>
        public string Tag { get; internal set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsOngoing { get; internal set; } = false;

        /// <summary>
        /// Gets a value that determines whether notification is displayed on the default viewer.
        /// If IsDisplay property set false and add style, you can see only style notification.
        /// </summary>
        public bool IsDisplay { get; internal set; } = true;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HasEventFlag { get; internal set; } = false;

        /// <summary>
        /// Gets the AppControl which is invoked when notification is clicked.
        /// </summary>
        public AppControl Action { get; internal set; }

        /// <summary>
        /// Gets the object of the progress notification.
        /// </summary>
        public ProgressArgs Progress { get; internal set; }

        /// <summary>
        /// Gets the AccessoryArgs which has option of Sound, Vibration, LED.
        /// </summary>
        public AccessoryArgs Accessory { get; internal set; }

        /// <summary>
        /// Gets the key for extender.
        /// </summary>
        public ICollection<string> ExtenderKey
        {
            get
            {
                return Extender.Keys;
            }
        }

        /// <summary>
        /// Gets the property.
        /// </summary>
        public NotificationProperty Property { get; internal set; }

        /// <summary>
        /// Gets the styleArgs of active, lock, indicator, bigpicture.
        /// </summary>
        /// <typeparam name="T">Type of notification style to be queried</typeparam>
        /// <returns>The NotificationEventListener.StyleArgs object associated with the given style</returns>
        /// <exception cref="ArgumentException">Thrown when argument is invalid</exception>
        public T GetStyle<T>() where T : StyleArgs, new()
        {
            T type = new T();
            StyleArgs style = null;

            Style.TryGetValue(type.Key, out style);

            if (style == null)
            {
                Log.Error(LogTag, "Invalid Style");
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered");
            }
            else
            {
                return style as T;
            }
        }

        /// <summary>
        /// Gets the ExtenderArgs.
        /// </summary>
        /// <param name="key">The key that specifies which extender</param>
        /// <returns>Returns the bundle for key</returns>
        public Bundle GetExtender(string key)
        {
            Bundle bundle;

            if (string.IsNullOrEmpty(key))
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered");
            }

            if (Extender.TryGetValue(key, out bundle) == false)
            {
                throw NotificationEventListenerErrorFactory.GetException(Interop.NotificationEventListener.ErrorCode.InvalidParameter, "invalid parameter entered : " + key);
            }

            return bundle;
        }
    }
}