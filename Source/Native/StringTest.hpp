#pragma once

#include "MarshalAPI.hpp"
#include <cstdint>

#define MARSHAL_API extern "C" MARSHAL_EXPORT

struct Vector2 {
    float x;
    float y;
};

/**
 * Returns the length of a C string.
 */
MARSHAL_API int32_t MRSH_StringLength(const char* str);

/**
 * Gets a string and reverses it.
 */
MARSHAL_API void MRSH_StringReverse(const char* src, char* dst);

MARSHAL_API float MRSH_VectorLength(const Vector2& vec);