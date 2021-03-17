#include <windows.h>
#include <stdio.h>

__declspec(dllexport) void crash(int *a)
{
    __try {
	printf("a: %d\n", *a);
        RaiseException(0x4242, 0, 0, NULL);
    }
    __finally {
        printf("finally a: %d\n", *a);
    }
}

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fdwReason, LPVOID lpReserved)
{
    return TRUE;
}
