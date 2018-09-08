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
// System.String
struct String_t;
// System.Collections.Generic.List`1<UnityEngine.GameObject>
struct List_1_t1125654279;
// System.Collections.Generic.List`1<System.Single>
struct List_1_t1445631064;
// BlockController
struct BlockController_t454875615;
// UnityEngine.GameObject[0...,0...]
struct GameObjectU5BU2CU5D_t3057952155;
// System.Int32[]
struct Int32U5BU5D_t3030399641;
// GameManagerController
struct GameManagerController_t760609751;
// BlockStatusController
struct BlockStatusController_t2608554987;
// PlayerController
struct PlayerController_t4148409433;
// UnityEngine.Material
struct Material_t193706927;
// UnityEngine.Renderer
struct Renderer_t257310565;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BlockStatusController
struct  BlockStatusController_t2608554987  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.GameObject BlockStatusController::firstBall
	GameObject_t1756533147 * ___firstBall_2;
	// UnityEngine.GameObject BlockStatusController::lastBall
	GameObject_t1756533147 * ___lastBall_3;
	// System.String BlockStatusController::currentName
	String_t* ___currentName_4;
	// System.Collections.Generic.List`1<UnityEngine.GameObject> BlockStatusController::removableBallList
	List_1_t1125654279 * ___removableBallList_5;
	// System.Collections.Generic.List`1<UnityEngine.GameObject> BlockStatusController::moveBlockList
	List_1_t1125654279 * ___moveBlockList_6;
	// System.Collections.Generic.List`1<System.Single> BlockStatusController::moveBlockPosYList
	List_1_t1445631064 * ___moveBlockPosYList_7;
	// UnityEngine.GameObject BlockStatusController::mainCam
	GameObject_t1756533147 * ___mainCam_8;
	// BlockController BlockStatusController::bcScript
	BlockController_t454875615 * ___bcScript_9;
	// UnityEngine.GameObject[0...,0...] BlockStatusController::moveObjects
	GameObjectU5BU2CU5D_t3057952155* ___moveObjects_10;
	// System.Int32[] BlockStatusController::countDel
	Int32U5BU5D_t3030399641* ___countDel_11;
	// GameManagerController BlockStatusController::gmScript
	GameManagerController_t760609751 * ___gmScript_12;
	// BlockStatusController BlockStatusController::bsScript
	BlockStatusController_t2608554987 * ___bsScript_13;
	// PlayerController BlockStatusController::pScript
	PlayerController_t4148409433 * ___pScript_14;
	// UnityEngine.GameObject BlockStatusController::light
	GameObject_t1756533147 * ___light_15;
	// UnityEngine.Material BlockStatusController::originalMaterial1
	Material_t193706927 * ___originalMaterial1_16;
	// UnityEngine.Material BlockStatusController::originalMaterial2
	Material_t193706927 * ___originalMaterial2_17;
	// UnityEngine.Material BlockStatusController::originalMaterial3
	Material_t193706927 * ___originalMaterial3_18;
	// UnityEngine.Material BlockStatusController::originalMaterial4
	Material_t193706927 * ___originalMaterial4_19;
	// UnityEngine.Renderer BlockStatusController::renderer
	Renderer_t257310565 * ___renderer_20;

public:
	inline static int32_t get_offset_of_firstBall_2() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___firstBall_2)); }
	inline GameObject_t1756533147 * get_firstBall_2() const { return ___firstBall_2; }
	inline GameObject_t1756533147 ** get_address_of_firstBall_2() { return &___firstBall_2; }
	inline void set_firstBall_2(GameObject_t1756533147 * value)
	{
		___firstBall_2 = value;
		Il2CppCodeGenWriteBarrier(&___firstBall_2, value);
	}

	inline static int32_t get_offset_of_lastBall_3() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___lastBall_3)); }
	inline GameObject_t1756533147 * get_lastBall_3() const { return ___lastBall_3; }
	inline GameObject_t1756533147 ** get_address_of_lastBall_3() { return &___lastBall_3; }
	inline void set_lastBall_3(GameObject_t1756533147 * value)
	{
		___lastBall_3 = value;
		Il2CppCodeGenWriteBarrier(&___lastBall_3, value);
	}

	inline static int32_t get_offset_of_currentName_4() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___currentName_4)); }
	inline String_t* get_currentName_4() const { return ___currentName_4; }
	inline String_t** get_address_of_currentName_4() { return &___currentName_4; }
	inline void set_currentName_4(String_t* value)
	{
		___currentName_4 = value;
		Il2CppCodeGenWriteBarrier(&___currentName_4, value);
	}

	inline static int32_t get_offset_of_removableBallList_5() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___removableBallList_5)); }
	inline List_1_t1125654279 * get_removableBallList_5() const { return ___removableBallList_5; }
	inline List_1_t1125654279 ** get_address_of_removableBallList_5() { return &___removableBallList_5; }
	inline void set_removableBallList_5(List_1_t1125654279 * value)
	{
		___removableBallList_5 = value;
		Il2CppCodeGenWriteBarrier(&___removableBallList_5, value);
	}

	inline static int32_t get_offset_of_moveBlockList_6() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___moveBlockList_6)); }
	inline List_1_t1125654279 * get_moveBlockList_6() const { return ___moveBlockList_6; }
	inline List_1_t1125654279 ** get_address_of_moveBlockList_6() { return &___moveBlockList_6; }
	inline void set_moveBlockList_6(List_1_t1125654279 * value)
	{
		___moveBlockList_6 = value;
		Il2CppCodeGenWriteBarrier(&___moveBlockList_6, value);
	}

	inline static int32_t get_offset_of_moveBlockPosYList_7() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___moveBlockPosYList_7)); }
	inline List_1_t1445631064 * get_moveBlockPosYList_7() const { return ___moveBlockPosYList_7; }
	inline List_1_t1445631064 ** get_address_of_moveBlockPosYList_7() { return &___moveBlockPosYList_7; }
	inline void set_moveBlockPosYList_7(List_1_t1445631064 * value)
	{
		___moveBlockPosYList_7 = value;
		Il2CppCodeGenWriteBarrier(&___moveBlockPosYList_7, value);
	}

	inline static int32_t get_offset_of_mainCam_8() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___mainCam_8)); }
	inline GameObject_t1756533147 * get_mainCam_8() const { return ___mainCam_8; }
	inline GameObject_t1756533147 ** get_address_of_mainCam_8() { return &___mainCam_8; }
	inline void set_mainCam_8(GameObject_t1756533147 * value)
	{
		___mainCam_8 = value;
		Il2CppCodeGenWriteBarrier(&___mainCam_8, value);
	}

	inline static int32_t get_offset_of_bcScript_9() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___bcScript_9)); }
	inline BlockController_t454875615 * get_bcScript_9() const { return ___bcScript_9; }
	inline BlockController_t454875615 ** get_address_of_bcScript_9() { return &___bcScript_9; }
	inline void set_bcScript_9(BlockController_t454875615 * value)
	{
		___bcScript_9 = value;
		Il2CppCodeGenWriteBarrier(&___bcScript_9, value);
	}

	inline static int32_t get_offset_of_moveObjects_10() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___moveObjects_10)); }
	inline GameObjectU5BU2CU5D_t3057952155* get_moveObjects_10() const { return ___moveObjects_10; }
	inline GameObjectU5BU2CU5D_t3057952155** get_address_of_moveObjects_10() { return &___moveObjects_10; }
	inline void set_moveObjects_10(GameObjectU5BU2CU5D_t3057952155* value)
	{
		___moveObjects_10 = value;
		Il2CppCodeGenWriteBarrier(&___moveObjects_10, value);
	}

	inline static int32_t get_offset_of_countDel_11() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___countDel_11)); }
	inline Int32U5BU5D_t3030399641* get_countDel_11() const { return ___countDel_11; }
	inline Int32U5BU5D_t3030399641** get_address_of_countDel_11() { return &___countDel_11; }
	inline void set_countDel_11(Int32U5BU5D_t3030399641* value)
	{
		___countDel_11 = value;
		Il2CppCodeGenWriteBarrier(&___countDel_11, value);
	}

	inline static int32_t get_offset_of_gmScript_12() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___gmScript_12)); }
	inline GameManagerController_t760609751 * get_gmScript_12() const { return ___gmScript_12; }
	inline GameManagerController_t760609751 ** get_address_of_gmScript_12() { return &___gmScript_12; }
	inline void set_gmScript_12(GameManagerController_t760609751 * value)
	{
		___gmScript_12 = value;
		Il2CppCodeGenWriteBarrier(&___gmScript_12, value);
	}

	inline static int32_t get_offset_of_bsScript_13() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___bsScript_13)); }
	inline BlockStatusController_t2608554987 * get_bsScript_13() const { return ___bsScript_13; }
	inline BlockStatusController_t2608554987 ** get_address_of_bsScript_13() { return &___bsScript_13; }
	inline void set_bsScript_13(BlockStatusController_t2608554987 * value)
	{
		___bsScript_13 = value;
		Il2CppCodeGenWriteBarrier(&___bsScript_13, value);
	}

	inline static int32_t get_offset_of_pScript_14() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___pScript_14)); }
	inline PlayerController_t4148409433 * get_pScript_14() const { return ___pScript_14; }
	inline PlayerController_t4148409433 ** get_address_of_pScript_14() { return &___pScript_14; }
	inline void set_pScript_14(PlayerController_t4148409433 * value)
	{
		___pScript_14 = value;
		Il2CppCodeGenWriteBarrier(&___pScript_14, value);
	}

	inline static int32_t get_offset_of_light_15() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___light_15)); }
	inline GameObject_t1756533147 * get_light_15() const { return ___light_15; }
	inline GameObject_t1756533147 ** get_address_of_light_15() { return &___light_15; }
	inline void set_light_15(GameObject_t1756533147 * value)
	{
		___light_15 = value;
		Il2CppCodeGenWriteBarrier(&___light_15, value);
	}

	inline static int32_t get_offset_of_originalMaterial1_16() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___originalMaterial1_16)); }
	inline Material_t193706927 * get_originalMaterial1_16() const { return ___originalMaterial1_16; }
	inline Material_t193706927 ** get_address_of_originalMaterial1_16() { return &___originalMaterial1_16; }
	inline void set_originalMaterial1_16(Material_t193706927 * value)
	{
		___originalMaterial1_16 = value;
		Il2CppCodeGenWriteBarrier(&___originalMaterial1_16, value);
	}

	inline static int32_t get_offset_of_originalMaterial2_17() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___originalMaterial2_17)); }
	inline Material_t193706927 * get_originalMaterial2_17() const { return ___originalMaterial2_17; }
	inline Material_t193706927 ** get_address_of_originalMaterial2_17() { return &___originalMaterial2_17; }
	inline void set_originalMaterial2_17(Material_t193706927 * value)
	{
		___originalMaterial2_17 = value;
		Il2CppCodeGenWriteBarrier(&___originalMaterial2_17, value);
	}

	inline static int32_t get_offset_of_originalMaterial3_18() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___originalMaterial3_18)); }
	inline Material_t193706927 * get_originalMaterial3_18() const { return ___originalMaterial3_18; }
	inline Material_t193706927 ** get_address_of_originalMaterial3_18() { return &___originalMaterial3_18; }
	inline void set_originalMaterial3_18(Material_t193706927 * value)
	{
		___originalMaterial3_18 = value;
		Il2CppCodeGenWriteBarrier(&___originalMaterial3_18, value);
	}

	inline static int32_t get_offset_of_originalMaterial4_19() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___originalMaterial4_19)); }
	inline Material_t193706927 * get_originalMaterial4_19() const { return ___originalMaterial4_19; }
	inline Material_t193706927 ** get_address_of_originalMaterial4_19() { return &___originalMaterial4_19; }
	inline void set_originalMaterial4_19(Material_t193706927 * value)
	{
		___originalMaterial4_19 = value;
		Il2CppCodeGenWriteBarrier(&___originalMaterial4_19, value);
	}

	inline static int32_t get_offset_of_renderer_20() { return static_cast<int32_t>(offsetof(BlockStatusController_t2608554987, ___renderer_20)); }
	inline Renderer_t257310565 * get_renderer_20() const { return ___renderer_20; }
	inline Renderer_t257310565 ** get_address_of_renderer_20() { return &___renderer_20; }
	inline void set_renderer_20(Renderer_t257310565 * value)
	{
		___renderer_20 = value;
		Il2CppCodeGenWriteBarrier(&___renderer_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
