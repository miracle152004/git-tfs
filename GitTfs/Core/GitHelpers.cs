using System;
using System.Text.RegularExpressions;

namespace Sep.Git.Tfs.Core
{
    public class GitHelpers : IGitHelpers
    {
        public string CommandOneline(params string[] command)
        {
            AssertValidCommand(command);
            // TODO - sub command_oneline
            // 1. start the child process and capture stdout (stderr?)
            // 2. Get the first line of output (if it's available) and trimend it.
            // 3. If _cmd_close (?) fails, add the output line and rethrow.
            // 4. Return the trimmed line.
            throw new NotImplementedException();
        }

        public void CommandNoisy(params string[] command)
        {
            AssertValidCommand(command);
            // TODO - sub command_noisy
            // 1. start the child process
            // 2. check the exit status, throw GitCommandException if (exitcode >> 8) != 0
            throw new NotImplementedException();
        }

        /// <summary>
        /// WrapGitCommandErrors the actions, and if there are any git exceptions, rethrow a new exception with the given message.
        /// </summary>
        /// <param name="exceptionMessage">A friendlier message to wrap the GitCommandException with. {0} is replaced with the command line and {1} is replaced with the exit code.</param>
        /// <param name="action"></param>
        public void WrapGitCommandErrors(string exceptionMessage, Action action)
        {
            try
            {
                action();
            }
            catch (GitCommandException e)
            {
                throw new Exception(String.Format(exceptionMessage, e.CommandLine, e.ExitCode), e);
            }
        }

        public IGitRepository MakeRepository(string dir)
        {
            return null;
        }

        private static readonly Regex ValidCommandName = new Regex("^[a-z0-9A-Z_-]+$");
        private static void AssertValidCommand(string[] command)
        {
            if(command.Length < 1 || !ValidCommandName.IsMatch(command[0]))
                throw new Exception("bad command: " + (command.Length == 0 ? "" : command[0]));
        }
    }
}