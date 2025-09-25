using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace EfectosBolivianos
{
    public class ModEntry : Mod
    {
        public override void Entry(IModHelper helper)
        {
            // Evento para detectar cuando se presiona una tecla
            helper.Events.Input.ButtonPressed += OnButtonPressed;
        }

        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            // Ignorar si el jugador aún no cargó la partida
            if (!Context.IsWorldReady)
                return;

            Farmer player = Game1.player;

            // Detectar si se presiona la tecla V
            if (e.Button == SButton.V)
            {
                // Aplicar buff temporal
                player.addedSpeed = 3f;   // +3 velocidad
                player.stamina += 50f;    // +50 energía
                Game1.addHUDMessage(new HUDMessage("Aumento de stamina", HUDMessage.achievement_type));
            }
        }
    }
}
