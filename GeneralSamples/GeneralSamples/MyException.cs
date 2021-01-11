using System;
using System.Collections;

namespace GeneralSamples
{
    class MyException
    {
        public static void ConvertWin32ErrorCodes()
        {            
            foreach (int errorCode in errorCodes.Keys)
            {
                System.ComponentModel.Win32Exception e = new System.ComponentModel.Win32Exception(errorCode, string.Format("{0}", errorCodes[errorCode]));
                Console.WriteLine("Exception: {0}, Native Error Code: {1}", e, e.NativeErrorCode);
            }            
        }

        public static void VerifyLogInnerException()
        {
            int intValue = 3;
            try
            {
                int result = intValue / 0;
            }
            catch (Exception ex)
            {
                string message = $"Exception: {ex}, inner exception: [{ex.InnerException}]";
                Console.WriteLine(message);
            }
        }

        public static void VerifyForceLogInnerException()
        {
            Console.WriteLine("Running VerifyForceLogInnerException ---- ----");
            Exception deepInnerException = new Exception("Example deep inner exception");
            Exception innerException = new Exception("Example inner exception", deepInnerException);
            Exception ex = new Exception("Example exception", innerException);
                        
            string message = $"Exception: {ex}, {Environment.NewLine}{Environment.NewLine} inner exception: [{ex.InnerException}]";
            Console.WriteLine(message);
            Console.WriteLine("Completed VerifyForceLogInnerException ---- ----");
        }

        public static void VerifyForceLogAggregateException()
        {
            int intValue = 3;
            try
            {
                int result = intValue / 0;
            }
            catch(Exception exception)
            {
                Console.WriteLine("Running VerifyForceLogAggregateException ---- ----");
                Exception innerException = new Exception("Example inner exception 1", exception);
                Exception innerException2 = exception;
                Exception innerException3 = new Exception("Example inner exception 2", exception);
                Exception ex = new AggregateException("Example Aggregate exception", new Exception[] { innerException, innerException2, innerException3});

                string message = $"Exception: {ex}, {Environment.NewLine}{Environment.NewLine} inner exception: [{ex.InnerException}]";
                Console.WriteLine(message);

                TraceException(ex);
                Console.WriteLine("Completed VerifyForceLogAggregateException ---- ----");
            }
        }

        public static void TraceException(Exception ex)
        {
            Console.WriteLine($"---- ---- TraceException: {ex}");
        }

        static Hashtable errorCodes = new Hashtable() {
            { 0x00000000, "The operation completed successfully.ERROR_SUCCESS" },
            { 0x00000001, "Incorrect function.ERROR_INVALID_FUNCTION" },
            { 0x00000002, "The system cannot find the file specified.ERROR_FILE_NOT_FOUND" },
            { 0x00000003, "The system cannot find the path specified.ERROR_PATH_NOT_FOUND" },
            { 0x00000004, "The system cannot open the file.ERROR_TOO_MANY_OPEN_FILES" },
            { 0x00000005, "Access is denied.ERROR_ACCESS_DENIED" },
            { 0x00000006, "The handle is invalid.ERROR_INVALID_HANDLE" },
            { 0x00000007, "The storage control blocks were destroyed.ERROR_ARENA_TRASHED" },
            { 0x00000008, "Not enough storage is available to process this command.ERROR_NOT_ENOUGH_MEMORY" },
            { 0x00000009, "The storage control block address is invalid.ERROR_INVALID_BLOCK" },
            { 0x0000000A, "The environment is incorrect.ERROR_BAD_ENVIRONMENT" },
            { 0x0000000B, "An attempt was made to load a program with an incorrect format.ERROR_BAD_FORMAT" },
            { 0x0000000C, "The access code is invalid.ERROR_INVALID_ACCESS" },
            { 0x0000000D, "The data is invalid.ERROR_INVALID_DATA" },
            { 0x0000000E, "Not enough storage is available to complete this operation.ERROR_OUTOFMEMORY" },
            { 0x0000000F, "The system cannot find the drive specified.ERROR_INVALID_DRIVE" },
            { 0x00000010, "The directory cannot be removed.ERROR_CURRENT_DIRECTORY" },
            { 0x00000011, "The system cannot move the file to a different disk drive.ERROR_NOT_SAME_DEVICE" },
            { 0x00000012, "There are no more files.ERROR_NO_MORE_FILES" },
            { 0x00000013, "The media is write-protected.ERROR_WRITE_PROTECT" },
            { 0x00000014, "The system cannot find the device specified.ERROR_BAD_UNIT" },
            { 0x00000015, "The device is not ready.ERROR_NOT_READY" },
            { 0x00000016, "The device does not recognize the command.ERROR_BAD_COMMAND" },
            { 0x00000017, "Data error (cyclic redundancy check).ERROR_CRC" },
            { 0x00000018, "The program issued a command but the command length is incorrect.ERROR_BAD_LENGTH" },
            { 0x00000019, "The drive cannot locate a specific area or track on the disk.ERROR_SEEK" },
            { 0x0000001A, "The specified disk cannot be accessed.ERROR_NOT_DOS_DISK" },
            { 0x0000001B, "The drive cannot find the sector requested.ERROR_SECTOR_NOT_FOUND" },
            { 0x0000001C, "The printer is out of paper.ERROR_OUT_OF_PAPER" },
            { 0x0000001D, "The system cannot write to the specified device.ERROR_WRITE_FAULT" },
            { 0x0000001E, "The system cannot read from the specified device.ERROR_READ_FAULT" },
            { 0x0000001F, "A device attached to the system is not functioning.ERROR_GEN_FAILURE" },
            { 0x00000020, "The process cannot access the file because it is being used by another process.ERROR_SHARING_VIOLATION" },
            { 0x00000021, "The process cannot access the file because another process has locked a portion of the file.ERROR_LOCK_VIOLATION" },
            { 0x00000022, "The wrong disk is in the drive. Insert %2 (Volume Serial Number: %3) into drive %1.ERROR_WRONG_DISK" },
            { 0x00000024, "Too many files opened for sharing.ERROR_SHARING_BUFFER_EXCEEDED" },
            { 0x00000026, "Reached the end of the file.ERROR_HANDLE_EOF" },
            { 0x00000027, "The disk is full.ERROR_HANDLE_DISK_FULL" },
            { 0x00000032, "The request is not supported.ERROR_NOT_SUPPORTED" },
            { 0x00000033, "Windows cannot find the network path. Verify that the network path is correct and the destination computer is not busy or turned off. If Windows still cannot find the network path, contact your network administrator.ERROR_REM_NOT_LIST" },
            { 0x00000034, "You were not connected because a duplicate name exists on the network. Go to System in Control Panel to change the computer name, and then try again.ERROR_DUP_NAME" },
            { 0x00000035, "The network path was not found.ERROR_BAD_NETPATH" },
            { 0x00000036, "The network is busy.ERROR_NETWORK_BUSY" },
            { 0x00000037, "The specified network resource or device is no longer available.ERROR_DEV_NOT_EXIST" },
            { 0x00000038, "The network BIOS command limit has been reached.ERROR_TOO_MANY_CMDS" },
            { 0x00000039, "A network adapter hardware error occurred.ERROR_ADAP_HDW_ERR" },
            { 0x0000003A, "The specified server cannot perform the requested operation.ERROR_BAD_NET_RESP" },
            { 0x0000003B, "An unexpected network error occurred.ERROR_UNEXP_NET_ERR" },
            { 0x0000003C, "The remote adapter is not compatible.ERROR_BAD_REM_ADAP" },
            { 0x0000003D, "The print queue is full.ERROR_PRINTQ_FULL" },
            { 0x0000003E, "Space to store the file waiting to be printed is not available on the server.ERROR_NO_SPOOL_SPACE" },
            { 0x0000003F, "Your file waiting to be printed was deleted.ERROR_PRINT_CANCELLED" },
            { 0x00000040, "The specified network name is no longer available.ERROR_NETNAME_DELETED" },
            { 0x00000041, "Network access is denied.ERROR_NETWORK_ACCESS_DENIED" },
            { 0x00000042, "The network resource type is not correct.ERROR_BAD_DEV_TYPE" },
            { 0x00000043, "The network name cannot be found.ERROR_BAD_NET_NAME" },
            { 0x00000044, "The name limit for the local computer network adapter card was exceeded.ERROR_TOO_MANY_NAMES" },
            { 0x00000045, "The network BIOS session limit was exceeded.ERROR_TOO_MANY_SESS" },
            { 0x00000046, "The remote server has been paused or is in the process of being started.ERROR_SHARING_PAUSED" },
            { 0x00000047, "No more connections can be made to this remote computer at this time because the computer has accepted the maximum number of connections.ERROR_REQ_NOT_ACCEP" },
            { 0x00000048, "The specified printer or disk device has been paused.ERROR_REDIR_PAUSED" },
            { 0x00000050, "The file exists.ERROR_FILE_EXISTS" },
            { 0x00000052, "The directory or file cannot be created.ERROR_CANNOT_MAKE" },
            { 0x00000053, "Fail on INT 24.ERROR_FAIL_I24" },
            { 0x00000054, "Storage to process this request is not available.ERROR_OUT_OF_STRUCTURES" },
            { 0x00000055, "The local device name is already in use.ERROR_ALREADY_ASSIGNED" },
            { 0x00000056, "The specified network password is not correct.ERROR_INVALID_PASSWORD" },
            { 0x00000057, "The parameter is incorrect.ERROR_INVALID_PARAMETER" },
            { 0x00000058, "A write fault occurred on the network.ERROR_NET_WRITE_FAULT" },
            { 0x00000059, "The system cannot start another process at this time.ERROR_NO_PROC_SLOTS" },
            { 0x00000064, "Cannot create another system semaphore.ERROR_TOO_MANY_SEMAPHORES" },
            { 0x00000065, "The exclusive semaphore is owned by another process.ERROR_EXCL_SEM_ALREADY_OWNED" },
            { 0x00000066, "The semaphore is set and cannot be closed.ERROR_SEM_IS_SET" },
            { 0x00000067, "The semaphore cannot be set again.ERROR_TOO_MANY_SEM_REQUESTS" },
            { 0x00000068, "Cannot request exclusive semaphores at interrupt time.ERROR_INVALID_AT_INTERRUPT_TIME" },
            { 0x00000069, "The previous ownership of this semaphore has ended.ERROR_SEM_OWNER_DIED" },
            { 0x0000006A, "Insert the disk for drive %1.ERROR_SEM_USER_LIMIT" },
            { 0x0000006B, "The program stopped because an alternate disk was not inserted.ERROR_DISK_CHANGE" },
            { 0x0000006C, "The disk is in use or locked by another process.ERROR_DRIVE_LOCKED" },
            { 0x0000006D, "The pipe has been ended.ERROR_BROKEN_PIPE" },
            { 0x0000006E, "The system cannot open the device or file specified.ERROR_OPEN_FAILED" },
            { 0x0000006F, "The file name is too long.ERROR_BUFFER_OVERFLOW" },
            { 0x00000070, "There is not enough space on the disk.ERROR_DISK_FULL" },
            { 0x00000071, "No more internal file identifiers are available.ERROR_NO_MORE_SEARCH_HANDLES" },
            { 0x00000072, "The target internal file identifier is incorrect.ERROR_INVALID_TARGET_HANDLE" },
            { 0x00000075, "The Input Output Control (IOCTL) call made by the application program is not correct.ERROR_INVALID_CATEGORY" },
            { 0x00000076, "The verify-on-write switch parameter value is not correct.ERROR_INVALID_VERIFY_SWITCH" },
            { 0x00000077, "The system does not support the command requested.ERROR_BAD_DRIVER_LEVEL" },
            { 0x00000078, "This function is not supported on this system.ERROR_CALL_NOT_IMPLEMENTED" },
            { 0x00000079, "The semaphore time-out period has expired.ERROR_SEM_TIMEOUT" },
            { 0x0000007A, "The data area passed to a system call is too small.ERROR_INSUFFICIENT_BUFFER" },
            { 0x0000007B, "The file name, directory name, or volume label syntax is incorrect.ERROR_INVALID_NAME" },
            { 0x0000007C, "The system call level is not correct.ERROR_INVALID_LEVEL" },
            { 0x0000007D, "The disk has no volume label.ERROR_NO_VOLUME_LABEL" },
            { 0x0000007E, "The specified module could not be found.ERROR_MOD_NOT_FOUND" },
            { 0x0000007F, "The specified procedure could not be found.ERROR_PROC_NOT_FOUND" },
            { 0x00000080, "There are no child processes to wait for.ERROR_WAIT_NO_CHILDREN" },
            { 0x00000081, "The %1 application cannot be run in Win32 mode.ERROR_CHILD_NOT_COMPLETE" },
            { 0x00000082, "Attempt to use a file handle to an open disk partition for an operation other than raw disk I/O.ERROR_DIRECT_ACCESS_HANDLE" },
            { 0x00000083, "An attempt was made to move the file pointer before the beginning of the file.ERROR_NEGATIVE_SEEK" },
            { 0x00000084, "The file pointer cannot be set on the specified device or file.ERROR_SEEK_ON_DEVICE" },
            { 0x00000085, "A�JOIN�or�SUBST�command cannot be used for a drive that contains previously joined drives.ERROR_IS_JOIN_TARGET" },
            { 0x00000086, "An attempt was made to use a�JOIN�or�SUBST�command on a drive that has already been joined.ERROR_IS_JOINED" },
            { 0x00000087, "An attempt was made to use a�JOIN�or�SUBST�command on a drive that has already been substituted.ERROR_IS_SUBSTED" },
            { 0x00000088, "The system tried to delete the�JOIN�of a drive that is not joined.ERROR_NOT_JOINED" },
            { 0x00000089, "The system tried to delete the substitution of a drive that is not substituted.ERROR_NOT_SUBSTED" },
            { 0x0000008A, "The system tried to join a drive to a directory on a joined drive.ERROR_JOIN_TO_JOIN" },
            { 0x0000008B, "The system tried to substitute a drive to a directory on a substituted drive.ERROR_SUBST_TO_SUBST" },
            { 0x0000008C, "The system tried to join a drive to a directory on a substituted drive.ERROR_JOIN_TO_SUBST" },
            { 0x0000008D, "The system tried to�SUBST�a drive to a directory on a joined drive.ERROR_SUBST_TO_JOIN" },
            { 0x0000008E, "The system cannot perform a�JOIN�or�SUBST�at this time.ERROR_BUSY_DRIVE" },
            { 0x0000008F, "The system cannot join or substitute a drive to or for a directory on the same drive.ERROR_SAME_DRIVE" },
            { 0x00000090, "The directory is not a subdirectory of the root directory.ERROR_DIR_NOT_ROOT" },
            { 0x00000091, "The directory is not empty.ERROR_DIR_NOT_EMPTY" },
            { 0x00000092, "The path specified is being used in a substitute.ERROR_IS_SUBST_PATH" },
            { 0x00000093, "Not enough resources are available to process this command.ERROR_IS_JOIN_PATH" },
            { 0x00000094, "The path specified cannot be used at this time.ERROR_PATH_BUSY" },
            { 0x00000095, "An attempt was made to join or substitute a drive for which a directory on the drive is the target of a previous substitute.ERROR_IS_SUBST_TARGET" },
            { 0x00000096, "System trace information was not specified in your CONFIG.SYS file, or tracing is disallowed.ERROR_SYSTEM_TRACE" },
            { 0x00000097, "The number of specified semaphore events for DosMuxSemWait is not correct.ERROR_INVALID_EVENT_COUNT" },
            { 0x00000098, "DosMuxSemWait did not execute; too many semaphores are already set.ERROR_TOO_MANY_MUXWAITERS" },
            { 0x00000099, "The DosMuxSemWait list is not correct.ERROR_INVALID_LIST_FORMAT" },
            { 0x0000009A, "The volume label you entered exceeds the label character limit of the destination file system.ERROR_LABEL_TOO_LONG" },
            { 0x0000009B, "Cannot create another thread.ERROR_TOO_MANY_TCBS" },
            { 0x0000009C, "The recipient process has refused the signal.ERROR_SIGNAL_REFUSED" },
            { 0x0000009D, "The segment is already discarded and cannot be locked.ERROR_DISCARDED" },
            { 0x0000009E, "The segment is already unlocked.ERROR_NOT_LOCKED" },
            { 0x0000009F, "The address for the thread ID is not correct.ERROR_BAD_THREADID_ADDR" },
            { 0x000000A0, "One or more arguments are not correct.ERROR_BAD_ARGUMENTS" },
            { 0x000000A1, "The specified path is invalid.ERROR_BAD_PATHNAME" },
            { 0x000000A2, "A signal is already pending.ERROR_SIGNAL_PENDING" },
            { 0x000000A4, "No more threads can be created in the system.ERROR_MAX_THRDS_REACHED" },
            { 0x000000A7, "Unable to lock a region of a file.ERROR_LOCK_FAILED" },
            { 0x000000AA, "The requested resource is in use.ERROR_BUSY" },
            { 0x000000AD, "A lock request was not outstanding for the supplied cancel region.ERROR_CANCEL_VIOLATION" },
            { 0x000000AE, "The file system does not support atomic changes to the lock type.ERROR_ATOMIC_LOCKS_NOT_SUPPORTED" },
            { 0x000000B4, "The system detected a segment number that was not correct.ERROR_INVALID_SEGMENT_NUMBER" },
            { 0x000000B6, "The operating system cannot run %1.ERROR_INVALID_ORDINAL" },
            { 0x000000B7, "Cannot create a file when that file already exists.ERROR_ALREADY_EXISTS" },
            { 0x000000BA, "The flag passed is not correct.ERROR_INVALID_FLAG_NUMBER" },
            { 0x000000BB, "The specified system semaphore name was not found.ERROR_SEM_NOT_FOUND" },
            { 0x000000BC, "The operating system cannot run %1.ERROR_INVALID_STARTING_CODESEG" },
            { 0x000000BD, "The operating system cannot run %1.ERROR_INVALID_STACKSEG" },
            { 0x000000BE, "The operating system cannot run %1.ERROR_INVALID_MODULETYPE" },
            { 0x000000BF, "Cannot run %1 in Win32 mode.ERROR_INVALID_EXE_SIGNATURE" },
            { 0x000000C0, "The operating system cannot run %1.ERROR_EXE_MARKED_INVALID" },
            { 0x000000C1, "%1 is not a valid Win32 application.ERROR_BAD_EXE_FORMAT" },
            { 0x000000C2, "The operating system cannot run %1.ERROR_ITERATED_DATA_EXCEEDS_64k" },
            { 0x000000C3, "The operating system cannot run %1.ERROR_INVALID_MINALLOCSIZE" },
            { 0x000000C4, "The operating system cannot run this application program.ERROR_DYNLINK_FROM_INVALID_RING" },
            { 0x000000C5, "The operating system is not presently configured to run this application.ERROR_IOPL_NOT_ENABLED" },
            { 0x000000C6, "The operating system cannot run %1.ERROR_INVALID_SEGDPL" },
            { 0x000000C7, "The operating system cannot run this application program.ERROR_AUTODATASEG_EXCEEDS_64k" },
            { 0x000000C8, "The code segment cannot be greater than or equal to 64 KB.ERROR_RING2SEG_MUST_BE_MOVABLE" },
            { 0x000000C9, "The operating system cannot run %1.ERROR_RELOC_CHAIN_XEEDS_SEGLIM" },
            { 0x000000CA, "The operating system cannot run %1.ERROR_INFLOOP_IN_RELOC_CHAIN" },
            { 0x000000CB, "The system could not find the environment option that was entered.ERROR_ENVVAR_NOT_FOUND" },
            { 0x000000CD, "No process in the command subtree has a signal handler.ERROR_NO_SIGNAL_SENT" },
            { 0x000000CE, "The file name or extension is too long.ERROR_FILENAME_EXCED_RANGE" },
            { 0x000000CF, "The ring 2 stack is in use.ERROR_RING2_STACK_IN_USE" },
            { 0x000000D0, "The asterisk (*) or question mark (?) global file name characters are entered incorrectly, or too many global file name characters are specified.ERROR_META_EXPANSION_TOO_LONG" },
            { 0x000000D1, "The signal being posted is not correct.ERROR_INVALID_SIGNAL_NUMBER" },
            { 0x000000D2, "The signal handler cannot be set.ERROR_THREAD_1_INACTIVE" },
            { 0x000000D4, "The segment is locked and cannot be reallocated.ERROR_LOCKED" },
            { 0x000000D6, "Too many dynamic-link modules are attached to this program or dynamic-link module.ERROR_TOO_MANY_MODULES" },
            { 0x000000D7, "Cannot nest calls to LoadModule.ERROR_NESTING_NOT_ALLOWED" },
            { 0x000000D8, "This version of %1 is not compatible with the version of Windows you're running. Check your computer's system information to see whether you need an x86 (32-bit) or x64 (64-bit) version of the program, and then contact the software publisher.ERROR_EXE_MACHINE_TYPE_MISMATCH" },
            { 0x000000D9, "The image file %1 is signed, unable to modify.ERROR_EXE_CANNOT_MODIFY_SIGNED_BINARY" },
            { 0x000000DA, "The image file %1 is strong signed, unable to modify.ERROR_EXE_CANNOT_MODIFY_STRONG_SIGNED_BINARY" },
            { 0x000000DC, "This file is checked out or locked for editing by another user.ERROR_FILE_CHECKED_OUT" },
            { 0x000000DD, "The file must be checked out before saving changes.ERROR_CHECKOUT_REQUIRED" },
            { 0x000000DE, "The file type being saved or retrieved has been blocked.ERROR_BAD_FILE_TYPE" },
            { 0x000000DF, "The file size exceeds the limit allowed and cannot be saved.ERROR_FILE_TOO_LARGE" },
            { 0x000000E0, "Access denied. Before opening files in this location, you must first browse to the website and select the option to sign in automatically.ERROR_FORMS_AUTH_REQUIRED" },
            { 0x000000E1, "Operation did not complete successfully because the file contains a virus.ERROR_VIRUS_INFECTED" },
            { 0x000000E2, "This file contains a virus and cannot be opened. Due to the nature of this virus, the file has been removed from this location.ERROR_VIRUS_DELETED" },
            { 0x000000E5, "The pipe is local.ERROR_PIPE_LOCAL" },
            { 0x000000E6, "The pipe state is invalid.ERROR_BAD_PIPE" },
            { 0x000000E7, "All pipe instances are busy.ERROR_PIPE_BUSY" },
            { 0x000000E8, "The pipe is being closed.ERROR_NO_DATA" },
            { 0x000000E9, "No process is on the other end of the pipe.ERROR_PIPE_NOT_CONNECTED" },
            { 0x000000EA, "More data is available.ERROR_MORE_DATA" },
            { 0x000000F0, "The session was canceled.ERROR_VC_DISCONNECTED" },
            { 0x000000FE, "The specified extended attribute name was invalid.ERROR_INVALID_EA_NAME" },
        };
    }
}
