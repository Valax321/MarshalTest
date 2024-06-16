include(GenerateExportHeader)

set(CMAKE_CXX_VISIBILITY_PRESET hidden)

set(Native_SRCS
"SDLTest.cpp"
"SDLTest.hpp"
"StringTest.cpp"
"StringTest.hpp"
)

add_library(MarshalNative SHARED ${Native_SRCS})
generate_export_header(MarshalNative BASE_NAME marshal EXPORT_FILE_NAME ${CMAKE_CURRENT_BINARY_DIR}/h/MarshalAPI.hpp)
target_include_directories(MarshalNative PUBLIC ${CMAKE_CURRENT_SOURCE_DIR} ${CMAKE_CURRENT_BINARY_DIR}/h)
target_link_libraries(MarshalNative SDL2)
