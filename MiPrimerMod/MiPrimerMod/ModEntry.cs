using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace MiPrimerMod 
{
    /// <summary>El punto de entrada del mod.</summary>
    public class ModEntry : Mod
    {
        /*********
        ** Métodos públicos
        *********/
        /// <summary>El punto de entrada del mod, invocado cuando el mod se carga por primera vez.</summary>
        /// <param name="helper">Proporciona referencias API simplificadas al escribir mods.</param>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Input.ButtonPressed += this.OnButtonPressed;
        }


        /*********
        ** Métodos privados
        *********/
        /// <summary>Invocado cuando el jugador presiona un botón en el teclado, controlador, o ratón.</summary>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // ignora si el jugador aún no ha cargado una partida
            if (!Context.IsWorldReady)
                return;

            // muestra en la consola qué botón presionó el jugador
            this.Monitor.Log($"{Game1.player.Name} presionó {e.Button}.", LogLevel.Debug);
        }
    }
}
