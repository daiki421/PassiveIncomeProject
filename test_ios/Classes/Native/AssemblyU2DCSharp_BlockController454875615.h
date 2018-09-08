#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Boolean[0...,0...]
struct BooleanU5BU2CU5D_t3568034316;
// UnityEngine.GameObject[0...,0...]
struct GameObjectU5BU2CU5D_t3057952155;
// UnityEngine.Material[]
struct MaterialU5BU5D_t3123989686;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BlockController
struct  BlockController_t454875615  : public MonoBehaviour_t1158329972
{
public:
	// System.Single BlockController::scale
	float ___scale_2;
	// System.Int32 BlockController::BLOCK_LINE
	int32_t ___BLOCK_LINE_3;
	// System.Int32 BlockController::BLOCK_ROW
	int32_t ___BLOCK_ROW_4;
	// System.Single BlockController::blockPosX
	float ___blockPosX_5;
	// System.Single BlockController::blockPosY
	float ___blockPosY_6;
	// System.Boolean[0...,0...] BlockController::existObjects
	BooleanU5BU2CU5D_t3568034316* ___existObjects_7;
	// UnityEngine.GameObject[0...,0...] BlockController::blocks
	GameObjectU5BU2CU5D_t3057952155* ___blocks_8;
	// UnityEngine.Material[] BlockController::_material
	MaterialU5BU5D_t3123989686* ____material_9;
	// System.Int32 BlockController::materialNum
	int32_t ___materialNum_10;

public:
	inline static int32_t get_offset_of_scale_2() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___scale_2)); }
	inline float get_scale_2() const { return ___scale_2; }
	inline float* get_address_of_scale_2() { return &___scale_2; }
	inline void set_scale_2(float value)
	{
		___scale_2 = value;
	}

	inline static int32_t get_offset_of_BLOCK_LINE_3() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___BLOCK_LINE_3)); }
	inline int32_t get_BLOCK_LINE_3() const { return ___BLOCK_LINE_3; }
	inline int32_t* get_address_of_BLOCK_LINE_3() { return &___BLOCK_LINE_3; }
	inline void set_BLOCK_LINE_3(int32_t value)
	{
		___BLOCK_LINE_3 = value;
	}

	inline static int32_t get_offset_of_BLOCK_ROW_4() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___BLOCK_ROW_4)); }
	inline int32_t get_BLOCK_ROW_4() const { return ___BLOCK_ROW_4; }
	inline int32_t* get_address_of_BLOCK_ROW_4() { return &___BLOCK_ROW_4; }
	inline void set_BLOCK_ROW_4(int32_t value)
	{
		___BLOCK_ROW_4 = value;
	}

	inline static int32_t get_offset_of_blockPosX_5() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___blockPosX_5)); }
	inline float get_blockPosX_5() const { return ___blockPosX_5; }
	inline float* get_address_of_blockPosX_5() { return &___blockPosX_5; }
	inline void set_blockPosX_5(float value)
	{
		___blockPosX_5 = value;
	}

	inline static int32_t get_offset_of_blockPosY_6() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___blockPosY_6)); }
	inline float get_blockPosY_6() const { return ___blockPosY_6; }
	inline float* get_address_of_blockPosY_6() { return &___blockPosY_6; }
	inline void set_blockPosY_6(float value)
	{
		___blockPosY_6 = value;
	}

	inline static int32_t get_offset_of_existObjects_7() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___existObjects_7)); }
	inline BooleanU5BU2CU5D_t3568034316* get_existObjects_7() const { return ___existObjects_7; }
	inline BooleanU5BU2CU5D_t3568034316** get_address_of_existObjects_7() { return &___existObjects_7; }
	inline void set_existObjects_7(BooleanU5BU2CU5D_t3568034316* value)
	{
		___existObjects_7 = value;
		Il2CppCodeGenWriteBarrier(&___existObjects_7, value);
	}

	inline static int32_t get_offset_of_blocks_8() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___blocks_8)); }
	inline GameObjectU5BU2CU5D_t3057952155* get_blocks_8() const { return ___blocks_8; }
	inline GameObjectU5BU2CU5D_t3057952155** get_address_of_blocks_8() { return &___blocks_8; }
	inline void set_blocks_8(GameObjectU5BU2CU5D_t3057952155* value)
	{
		___blocks_8 = value;
		Il2CppCodeGenWriteBarrier(&___blocks_8, value);
	}

	inline static int32_t get_offset_of__material_9() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ____material_9)); }
	inline MaterialU5BU5D_t3123989686* get__material_9() const { return ____material_9; }
	inline MaterialU5BU5D_t3123989686** get_address_of__material_9() { return &____material_9; }
	inline void set__material_9(MaterialU5BU5D_t3123989686* value)
	{
		____material_9 = value;
		Il2CppCodeGenWriteBarrier(&____material_9, value);
	}

	inline static int32_t get_offset_of_materialNum_10() { return static_cast<int32_t>(offsetof(BlockController_t454875615, ___materialNum_10)); }
	inline int32_t get_materialNum_10() const { return ___materialNum_10; }
	inline int32_t* get_address_of_materialNum_10() { return &___materialNum_10; }
	inline void set_materialNum_10(int32_t value)
	{
		___materialNum_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
