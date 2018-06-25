//------------------------------------------------------------------------------
// <copyright file="ILikeable.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace DesignByContract
{
    using System;

    public interface ILikeable
    {
        Int32 Likes { get; }

        void Like();

        void Unlike();
    }
}