using System;
using System.Runtime.InteropServices;
using Mono.Unix;
using Mono.Unix.Native;

namespace Ketarin
{
    public class MaskedPermissions
    {
        private static uint umask_value = getUmask();

        public static uint getUmask()
        {
            uint _umask_value = umask(0);
            umask(_umask_value);
	    return _umask_value;
        }

        public static uint setMaskedPermissions(string path, FilePermissions mode)
        {
            uint _mode = NativeConvert.FromFilePermissions(mode);
            _mode = _mode & ~(umask_value);
            return chmod(path, _mode);
        }

        [System.Runtime.InteropServices.DllImport("libc", SetLastError=false, EntryPoint="umask")]
        private extern static uint umask(uint mask);

        [System.Runtime.InteropServices.DllImport("libc", SetLastError=true, EntryPoint="chmod")]
        private extern static uint chmod([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(FileNameMarshaler))] string path, uint mode);
    }

    class FileNameMarshaler : ICustomMarshaler
    {
        private static FileNameMarshaler instance = new FileNameMarshaler();
        public static ICustomMarshaler GetInstance(string s)
        {
            return instance;
        }

        public void CleanUpManagedData(Object obj)
        {
            // do nothing
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            UnixMarshal.FreeHeap(pNativeData);
        }

        public int GetNativeDataSize()
        {
            return IntPtr.Size;
        }

        public IntPtr MarshalManagedToNative(object obj)
        {
            String str = obj as string;
            if (str == null)
            {
                return IntPtr.Zero;
            }
            return UnixMarshal.StringToHeap(str, UnixEncoding.Instance);
        }

        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return UnixMarshal.PtrToString(pNativeData, UnixEncoding.Instance);
        }
    }
}
