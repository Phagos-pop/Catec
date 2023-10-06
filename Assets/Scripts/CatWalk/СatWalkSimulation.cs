using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using System;

namespace CatWalk
{
    public class СatWalkSimulation : MonoBehaviour
    {
        private float TICK_COOLDOWN = 0.01f;
        private float SPEED = 0.1f;

        [SerializeField] private GameObject _catFootPrefab;
        [SerializeField] private List<CatWalkPoint> _catWalkPoints;

        private GameObject _catFoot;
        private float _t;
        private float _Next_t;
        private int _pointCounter;
        private int _firstPoint;
        private int _secondPoint;
        private int _thirdPoint;
        private int _fourthPoint;

        private TimeSpan _timeFromLastTick => DateTime.Now - _lastTick;
        private DateTime _lastTick;

        private void Start()
        {
            _catFoot = Instantiate(_catFootPrefab, _catWalkPoints[0].Position, Quaternion.identity);
            SetPoints();
            _pointCounter = 0;
            _lastTick = DateTime.Now;
        }

        private void Update()
        {
            _t = Mathf.Lerp(_t, _Next_t, SPEED);

            _catFoot.transform.position = BezierCurve.GetPoint(
                _catWalkPoints[_firstPoint].Position,
                _catWalkPoints[_secondPoint].Position,
                _catWalkPoints[_thirdPoint].Position,
                _catWalkPoints[_fourthPoint].Position, _t);

            Tick();
        }

        private void Tick()
        {
            if (_timeFromLastTick > TimeSpan.FromSeconds(TICK_COOLDOWN))
            {
                _lastTick = DateTime.Now;
                if (_t < 1f)
                {
                    _Next_t += 0.005f;
                }
                else
                {
                    SetPoints();
                    _t = 0;
                    _Next_t = 0;
                }
            }
        }

        private void SetPoints()
        {
            if (_catWalkPoints.Count > _pointCounter)
                _firstPoint = _pointCounter;
            else
                _firstPoint = SetPoint();
            _secondPoint = SetPoint();
            _thirdPoint = SetPoint();
            _fourthPoint = SetPoint();
        }

        private int SetPoint()
        {
            if (_catWalkPoints.Count > _pointCounter)
            {
                _pointCounter++;
                return _pointCounter - 1;
            }
            _pointCounter = 0;
            return _pointCounter;
        }
    }
}