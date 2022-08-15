#pragma once

// Тут можно подключить scopedptr.h и ptrvector.h, 
// если они вам понадобятся.
#include "ptrvector.h"
#include "scopedptr.h"

#include <new> // Для исключения bad_alloc
#include <vector>

// Щупальце
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

// Осьминог
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
        // Осьминог владеет объектами в динамической памяти (щупальца),
        // которые должны быть удалены при его разрушении.
        // Деструктор - лучшее место, чтобы прибраться за собой.
    }

    // Добавляет новое щупальце с идентификатором,
    // равным (количество_щупалец + 1):
    // 1, 2, 3, ...
    // Возвращает ссылку на добавленное щупальце
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
    // Вектор хранит указатели на щупальца. Сами объекты щупалец находятся в куче
    //std::vector<Tentacle*> tentacles_;
    PtrVector<Tentacle> tentacles_;
};