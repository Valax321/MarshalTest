#pragma once

#include "MarshalAPI.hpp"
#include <cstdint>
#include <SDL2/SDL.h>

#define MARSHAL_API extern "C" MARSHAL_EXPORT

MARSHAL_API void MRSH_DoSomethingWithWindow(SDL_Window* wnd);
