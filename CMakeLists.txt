cmake_minimum_required(VERSION 3.25 FATAL_ERROR)

project(MarshalTest VERSION 1.0.0.0 LANGUAGES C CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED true)

if (NOT ${CMAKE_SYSTEM_NAME} MATCHES "Linux")
    add_subdirectory("ThirdParty/SDL")
    if (${CMAKE_SYSTEM_NAME} MATCHES "Darwin")
        set_target_properties(SDL2 PROPERTIES NO_SONAME ON OUTPUT_NAME "SDL2" DEBUG_POSTFIX "")
    endif()
endif()

add_subdirectory("Source/Native")
