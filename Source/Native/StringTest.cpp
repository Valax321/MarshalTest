#include "StringTest.hpp"

#include <algorithm>
#include <string>
#include <memory>
#include <cstdio>
#include <cmath>

int32_t MRSH_StringLength(const char* str) {
    if (str == nullptr)
        return -1;

    char8_t c = 0;
    size_t i = 0;

    do {
        c = str[i++];
    } while (c != 0);

    return static_cast<int32_t>(i - 1);
}

void MRSH_StringReverse(const char* src, char* dst) {
    std::printf("Received: %s, length: %zu\n", src, std::strlen(src));

    std::string buf(src);
    std::reverse(buf.begin(), buf.end());
    std::copy(buf.begin(), buf.end(), dst);
}

float MRSH_VectorLength(const Vector2& vec) {
    return std::sqrt((vec.x * vec.x) + (vec.y * vec.y));
}