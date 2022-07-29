using MyPrintiverse.Core.Utilities;

namespace MyPrintiverse.AdminModule;

public class AdminViewModel : BaseViewModel
{
	public ICommand Button1Command { get; }
	public ICommand Button2Command 	{ get; }
	public ICommand Button3Command 	{ get; }

	public ICommand Button4Command 	{ get; }
	public ICommand Button5Command 	{ get; }
	public ICommand Button6Command 	{ get; }

	public ICommand Button7Command 	{ get; }
	public ICommand Button8Command 	{ get; }
	public ICommand Button9Command 	{ get; }

	public ICommand Button10Command { get; }
	public ICommand Button11Command { get; }
	public ICommand Button12Command { get; }

	public ICommand Button13Command { get; }
	public ICommand Button14Command { get; }
	public ICommand Button15Command { get; }

	public AdminViewModel()
	{
		Button1Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button2Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button3Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);

		Button4Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button5Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button6Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);

		Button7Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button8Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button9Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);

		Button10Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button11Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button12Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);

		Button13Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button14Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
		Button15Command = new AsyncCommand(ExecuteButtonCommand, CanExecute, shellExecute: ExecuteBlockade);
	}

	public async Task ExecuteButtonCommand() => await Task.Run(() => 1 + 1);
}