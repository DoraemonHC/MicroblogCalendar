﻿#region License
// Copyright (c) 2007 James Newton-King
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;

namespace NetDimension.Json
{
  /// <summary>
  /// Specifies default value handling options for the <see cref="JsonSerializer"/>.
  /// </summary>
  [Flags]
  public enum DefaultValueHandling
  {
    /// <summary>
    /// Include members where the member value is the same as the member's default value when serializing objects.
    /// Included members are written to JSON. Has no effect when deserializing.
    /// </summary>
    Include = 0,
    /// <summary>
    /// Ignore members where the member value is the same as the member's default value when serializing objects
    /// so that is is not written to JSON, and ignores setting members when the JSON value equals the member's default value.
    /// </summary>
    Ignore = 1,
    /// <summary>
    /// Members with a default value but no JSON will be set to their default value when deserializing.
    /// </summary>
    Populate = 2,
    /// <summary>
    /// Ignore members where the member value is the same as the member's default value when serializing objects
    /// and sets members to their default value when deserializing.
    /// </summary>
    IgnoreAndPopulate = Ignore | Populate
  }
}