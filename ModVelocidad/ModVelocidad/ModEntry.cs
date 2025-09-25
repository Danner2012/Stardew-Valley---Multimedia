using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace ModVelocidad
{
    public class ModEntry : Mod
    {
        private int velocidadExtra = 0;

        public override void Entry(IModHelper helper)
        {
            // Evento de teclas
            helper.Events.Input.ButtonPressed += OnButtonPressed;

            // Evento que se ejecuta cada frame/tick
            helper.Events.GameLoop.UpdateTicked += OnUpdateTicked;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            // V -> super velocidad
            if (e.Button == SButton.V)
            {
                velocidadExtra = 100; 
                Monitor.Log("¡Super velocidad activada (+100)!", LogLevel.Info);
            }

            // B -> velocidad normal
            if (e.Button == SButton.B)
            {
                velocidadExtra = 0;
                Monitor.Log("Velocidad restaurada.", LogLevel.Info);
            }
        }

        private void OnUpdateTicked(object sender, UpdateTickedEventArgs e)
        {
            if (!Context.IsWorldReady)
                return;

            // Mantener siempre la velocidad aplicada
            Game1.player.addedSpeed = velocidadExtra;
        }
    }
}
