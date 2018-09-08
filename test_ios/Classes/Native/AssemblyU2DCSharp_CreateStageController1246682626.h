#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.GameObject
struct GameObject_t1756533147;
// BlockController
struct BlockController_t454875615;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CreateStageController
struct  CreateStageController_t1246682626  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.GameObject CreateStageController::floors
	GameObject_t1756533147 * ___floors_2;
	// BlockController CreateStageController::bcScript
	BlockController_t454875615 * ___bcScript_3;
	// UnityEngine.GameObject CreateStageController::mainCam
	GameObject_t1756533147 * ___mainCam_4;
	// System.Int32 CreateStageController::line
	int32_t ___line_5;
	// System.Single CreateStageController::wallPosX
	float ___wallPosX_6;
	// System.Single CreateStageController::wallPosY
	float ___wallPosY_7;
	// System.Single CreateStageController::colliderPosX
	float ___colliderPosX_8;
	// System.Single CreateStageController::colliderPosY
	float ___colliderPosY_9;
	// System.Single CreateStageController::scale
	float ___scale_10;

public:
	inline static int32_t get_offset_of_floors_2() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___floors_2)); }
	inline GameObject_t1756533147 * get_floors_2() const { return ___floors_2; }
	inline GameObject_t1756533147 ** get_address_of_floors_2() { return &___floors_2; }
	inline void set_floors_2(GameObject_t1756533147 * value)
	{
		___floors_2 = value;
		Il2CppCodeGenWriteBarrier(&___floors_2, value);
	}

	inline static int32_t get_offset_of_bcScript_3() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___bcScript_3)); }
	inline BlockController_t454875615 * get_bcScript_3() const { return ___bcScript_3; }
	inline BlockController_t454875615 ** get_address_of_bcScript_3() { return &___bcScript_3; }
	inline void set_bcScript_3(BlockController_t454875615 * value)
	{
		___bcScript_3 = value;
		Il2CppCodeGenWriteBarrier(&___bcScript_3, value);
	}

	inline static int32_t get_offset_of_mainCam_4() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___mainCam_4)); }
	inline GameObject_t1756533147 * get_mainCam_4() const { return ___mainCam_4; }
	inline GameObject_t1756533147 ** get_address_of_mainCam_4() { return &___mainCam_4; }
	inline void set_mainCam_4(GameObject_t1756533147 * value)
	{
		___mainCam_4 = value;
		Il2CppCodeGenWriteBarrier(&___mainCam_4, value);
	}

	inline static int32_t get_offset_of_line_5() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___line_5)); }
	inline int32_t get_line_5() const { return ___line_5; }
	inline int32_t* get_address_of_line_5() { return &___line_5; }
	inline void set_line_5(int32_t value)
	{
		___line_5 = value;
	}

	inline static int32_t get_offset_of_wallPosX_6() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___wallPosX_6)); }
	inline float get_wallPosX_6() const { return ___wallPosX_6; }
	inline float* get_address_of_wallPosX_6() { return &___wallPosX_6; }
	inline void set_wallPosX_6(float value)
	{
		___wallPosX_6 = value;
	}

	inline static int32_t get_offset_of_wallPosY_7() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___wallPosY_7)); }
	inline float get_wallPosY_7() const { return ___wallPosY_7; }
	inline float* get_address_of_wallPosY_7() { return &___wallPosY_7; }
	inline void set_wallPosY_7(float value)
	{
		___wallPosY_7 = value;
	}

	inline static int32_t get_offset_of_colliderPosX_8() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___colliderPosX_8)); }
	inline float get_colliderPosX_8() const { return ___colliderPosX_8; }
	inline float* get_address_of_colliderPosX_8() { return &___colliderPosX_8; }
	inline void set_colliderPosX_8(float value)
	{
		___colliderPosX_8 = value;
	}

	inline static int32_t get_offset_of_colliderPosY_9() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___colliderPosY_9)); }
	inline float get_colliderPosY_9() const { return ___colliderPosY_9; }
	inline float* get_address_of_colliderPosY_9() { return &___colliderPosY_9; }
	inline void set_colliderPosY_9(float value)
	{
		___colliderPosY_9 = value;
	}

	inline static int32_t get_offset_of_scale_10() { return static_cast<int32_t>(offsetof(CreateStageController_t1246682626, ___scale_10)); }
	inline float get_scale_10() const { return ___scale_10; }
	inline float* get_address_of_scale_10() { return &___scale_10; }
	inline void set_scale_10(float value)
	{
		___scale_10 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
