#include "SDLTest.hpp"

#include <cstdio>

void MRSH_DoSomethingWithWindow(SDL_Window* wnd) {
    if (wnd == nullptr)
        return;

    auto windowTitle = SDL_GetWindowTitle(wnd);
    std::printf("Window title: %s\n", windowTitle);
}