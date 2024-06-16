#include "StringTest.hpp"

#include <algorithm>
#include <string>
#include <memory>
#include <cstdio>
#include <cmath>

// None of these are very sensible candidates for P/Invoke, but they are
// solid enough examples of something that can be trivially done in C# to
// A/B results.

int32_t MRSH_StringLength(const char* str) {
    if (str == nullptr)
        return -1;

    return std::strlen(str);
}

void MRSH_StringReverse(const char* src, char* dst) {
    std::string buf(src);
    std::reverse(buf.begin(), buf.end());
    std::copy(buf.begin(), buf.end(), dst);
}

float MRSH_VectorLength(const Vector2& vec) {
    return std::sqrt((vec.x * vec.x) + (vec.y * vec.y));
}