#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Material[]
struct MaterialU5BU5D_t3123989686;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BlockExistController
struct  BlockExistController_t3376080160  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Material[] BlockExistController::_material
	MaterialU5BU5D_t3123989686* ____material_2;
	// System.Int32 BlockExistController::i
	int32_t ___i_3;

public:
	inline static int32_t get_offset_of__material_2() { return static_cast<int32_t>(offsetof(BlockExistController_t3376080160, ____material_2)); }
	inline MaterialU5BU5D_t3123989686* get__material_2() const { return ____material_2; }
	inline MaterialU5BU5D_t3123989686** get_address_of__material_2() { return &____material_2; }
	inline void set__material_2(MaterialU5BU5D_t3123989686* value)
	{
		____material_2 = value;
		Il2CppCodeGenWriteBarrier(&____material_2, value);
	}

	inline static int32_t get_offset_of_i_3() { return static_cast<int32_t>(offsetof(BlockExistController_t3376080160, ___i_3)); }
	inline int32_t get_i_3() const { return ___i_3; }
	inline int32_t* get_address_of_i_3() { return &___i_3; }
	inline void set_i_3(int32_t value)
	{
		___i_3 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
