#pragma once

// ��� ����� ���������� scopedptr.h � ptrvector.h, 
// ���� ��� ��� �����������.
#include "ptrvector.h"
#include "scopedptr.h"

#include <new> // ��� ���������� bad_alloc
#include <vector>

// ��������
class Tentacle {
public:
    explicit Tentacle(int id) noexcept
        : id_(id) {
    }

    int GetId() const noexcept {
        return id_;
    }

    Tentacle* GetLinkedTentacle() const noexcept {
        return linked_tentacle_;
    }
    void LinkTo(Tentacle& tentacle) noexcept {
        linked_tentacle_ = &tentacle;
    }
    void Unlink() noexcept {
        linked_tentacle_ = nullptr;
    }

private:
    int id_ = 0;
    Tentacle* linked_tentacle_ = nullptr;
};

// ��������
class Octopus {
public:
    Octopus()
        : Octopus(8) {
    }

    explicit Octopus(int num_tentacles) {
        tentacles_.GetItems().reserve(num_tentacles);
            for (int i = 1; i <= num_tentacles; ++i) {
                AddTentacle();
            }
    }

    ~Octopus() {
        // �������� ������� ��������� � ������������ ������ (��������),
        // ������� ������ ���� ������� ��� ��� ����������.
        // ���������� - ������ �����, ����� ���������� �� �����.
    }

    // ��������� ����� �������� � ���������������,
    // ������ (����������_������� + 1):
    // 1, 2, 3, ...
    // ���������� ������ �� ����������� ��������
     Tentacle& AddTentacle() {
         int i = tentacles_.GetItems().size() + 1;
         ScopedPtr<Tentacle> tentacle(new Tentacle(i));
         tentacles_.GetItems().push_back(tentacle.GetRawPtr());
         tentacle.Release();
         return *tentacles_.GetItems().back();
     }

     int GetTentacleCount() const noexcept {
         return static_cast<int>(tentacles_.GetItems().size());
     }

     const Tentacle& GetTentacle(size_t index) const {
         return *tentacles_.GetItems().at(index);
     }

     Tentacle& GetTentacle(size_t index) {
         return *tentacles_.GetItems().at(index);
         //auto pvec = tentacles_.GetItems();
         //return *pvec.at(index);
     }

private:
    // ������ ������ ��������� �� ��������. ���� ������� ������� ��������� � ����
    //std::vector<Tentacle*> tentacles_;
    PtrVector<Tentacle> tentacles_;
};